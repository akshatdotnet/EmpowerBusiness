using Empower.Data.Entities;
using Empower.Data.Repository;
using Empower.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.Account
{
    public class AccountBL : IAccountBL
    {
        private readonly IRepository<User> _user;        
        public AccountBL(IRepository<User> user)
        {
            _user = user;
        }

        public async Task<SignUpOutputDTO> AddUser(SignUpInputDTO input)
        {
            if (await IsUserMobileExist(input.Mobile))
            {
                return new SignUpOutputDTO()
                {
                    MobileNumberAlredyUsed = true
                };
            }
            if (await IsUserEmailExist(input.EmailId))
            {
                return new SignUpOutputDTO()
                {
                    EmailAlredyUsed = true
                };
            }
            else
            {
                string encryptedDBPassword = EncryptDecrypt.Encrypt(input.Password);
                var user = new User
                {
                    UserEmail = input.EmailId,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                    IsActive = true,
                    MobileNumber = input.Mobile,
                    PasswordHash = encryptedDBPassword,
                    UserDetail = new UserDetail
                    {
                        IsDeleted = false,
                        FirstName = input.FirstName,
                        LastName = input.LastName,
                        UserType = "Registered"
                    }
                };
                await _user.Add(user);
                return new SignUpOutputDTO()
                {
                    UserId = user.Id
                };
            }
        }
        public async Task<LoginOutputDTO?> GetValidUser(LoginInputDTO login)
        {
            LoginOutputDTO? userVM = null;
            string decryptedDBPassword = string.Empty;

            var user = await _user.GetWhere(x => (x.MobileNumber == login.EmailMobile || x.UserEmail == login.EmailMobile) && !x.IsDeleted).Include(x => x.UserDetail).FirstOrDefaultAsync();

            if (user != null)
            {
                decryptedDBPassword = EncryptDecrypt.Decrypt(user.PasswordHash ?? "");

                if (login.Password == decryptedDBPassword)
                {
                    userVM = new()
                    {
                        Id = user.Id,
                        UserEmail = user.UserEmail,
                        IsActive = user.IsActive,
                        IsEmailVerified = user.IsEmailVerified,
                        UniqueId = user.UniqueId,
                        FirstName = user.UserDetail?.FirstName ?? "",
                        LastName = user.UserDetail?.LastName ?? "",
                        MobileNo = user?.MobileNumber ?? ""
                    };
                }
            }

            return userVM;
        }
        public async Task<bool> IsUserMobileExist(string mobile, int id = 0)
        {
            bool isExist = false;
            if (!string.IsNullOrEmpty(mobile))
            {
                if (id > 0)
                {
                    //Edit Case
                    isExist = _user.Any(x => x.Id != id && x.MobileNumber == mobile);
                }
                else
                {
                    //Add Case
                    isExist = _user.Any(x => x.MobileNumber == mobile);
                }
            }
            return await Task.FromResult(isExist);
        }
        public async Task<bool> IsUserEmailExist(string email, int id = 0)
        {
            bool isExist = false;
            if (!string.IsNullOrEmpty(email))
            {
                if (id > 0)
                {
                    //Edit Case
                    isExist = _user.Any(x => x.Id != id && x.UserEmail.ToLower() == email.ToLower());
                }
                else
                {
                    //Add Case
                    isExist = _user.Any(x => x.UserEmail.ToLower() == email.ToLower());
                }
            }
            return await Task.FromResult(isExist);
        }

        public async Task<string> GenerateUserForgotPasswordToken(string email)
        {
            var token = "";
            var user = await _user.GetWhere(x => x.UserEmail == email && x.IsActive && x.IsDeleted == false).FirstOrDefaultAsync();
            if (user != null)
            {
                token = Guid.NewGuid().ToString();
                user.LastResetPasswordCreatedDate = DateTime.UtcNow;
                user.ResetPasswordToken = token;
                await _user.Update(user);
            }
            return token;
        }

        public async Task MarkUserActive(int userId)
        {
            var user = await _user.GetById(userId);
            if (user != null)
            {
                user.IsActive = true;
                await _user.Update(user);
            }
        }

        public async Task<UserOutputDTO> GetAllUser(string filter = "")
        {
            var model = new UserOutputDTO()
            {
                IsAddMode = false,
                IsEditMode = false,
                SelectedFilter = ""
            };
            var result = await GetAllUser();

            model.List = result;
            if (!string.IsNullOrEmpty(filter))
            {
                model.SelectedFilter = filter;
                filter = filter.ToLower();
                model.List = result.Where(x =>
                (x.FirstName ?? "").ToLower().Contains(filter) ||
                (x.MobileNumber ?? "").Contains(filter) ||
                (x.UserEmail ?? "").Contains(filter) ||
                (x.RoleName ?? "").ToLower().Contains(filter) ||
                x.CreatedOn.Contains(filter)
                ).ToList();
            }

            return model;
        }
        public async Task<List<UserDTO>> GetAllUser()
        {
            var query = _user.GetWhere(x => x.IsDeleted == false);
            var result = await query.Include(x => x.UserDetail).Include(x => x.UserRole).ToListAsync();
            return result.Select(x => new UserDTO()
            {
                Id = x.Id,
                FirstName = x.UserDetail?.FirstName ?? "",
                MobileNumber = x.MobileNumber,
                UserEmail = x.UserEmail,
                RoleName = x.UserRole?.Name ?? "",
                RoleId = x.UserRole?.Id ?? 0,
                CreatedOn = x.CreatedOn.ToGlobalDateFormatWithTime(),
                IsActive = x.IsActive,
                LastLoggedIn = x.LastLoggedIn?.ToGlobalDateFormatWithTime()
            }).ToList();
        }

        public async Task<UserInsertOutputDto> InsertUser(UserInputDTO model)
        {
            if (await IsUserMobileExist(model.MobileNumber, 0))
            {
                return new UserInsertOutputDto()
                {
                    UserMobileAlredyExist = true
                };
            }
            if (await IsUserEmailExist(model.UserEmail, 0))
            {
                return new UserInsertOutputDto()
                {
                    UserEmailAlredyExist = true
                };
            }

            string encryptedDBPassword = EncryptDecrypt.Encrypt(model.Password);
            await _user.Add(new User()
            {
                UserDetail = new UserDetail()
                {
                    FirstName = model.FirstName,
                    CreatedBy = model.CreatedBy,

                },
                MobileNumber = model.MobileNumber,
                CreatedBy = model.CreatedBy,
                UserRoleId = model.RoleId ?? 1,
                UserEmail = model.UserEmail,
                //UserName = model.UserEmail,
                PasswordHash = encryptedDBPassword,
                IsActive = model.IsActive,
                IsDeleted = false
            });
            return new UserInsertOutputDto()
            {

            };

        }

        public async Task<UserDTO?> GetUserById(int id)
        {
            var result = await _user.GetWhere(x => x.Id == id && !x.IsDeleted).Include(x => x.UserRole).Include(x => x.UserDetail).FirstOrDefaultAsync();
            if (result != null)
            {
                return new UserDTO()
                {
                    Id = result.Id,
                    FirstName = result.UserDetail?.FirstName,
                    MobileNumber = result.MobileNumber,
                    UserEmail = result.UserEmail,
                    RoleId = result.UserRole?.Id,
                    CreatedOn = result.CreatedOn.ToGlobalDateFormatWithTime(),
                    IsActive = result.IsActive,
                    LastLoggedIn = result.LastLoggedIn?.ToGlobalDateFormatWithTime()
                };
            }
            return null;
        }

        public async Task<UserUpdateOutputDto> UpdateUser(UserInputDTO model)
        {
            if (await IsUserMobileExist(model.MobileNumber, model.Id))
            {
                return new UserUpdateOutputDto()
                {
                    UserMobileAlredyExist = true
                };
            }
            if (await IsUserEmailExist(model.UserEmail, model.Id))
            {
                return new UserUpdateOutputDto()
                {
                    UserEmailAlredyExist = true
                };
            }
            else
            {
                var entity = await _user.GetWhere(x => x.Id == model.Id).Include(x => x.UserRole).Include(x => x.UserDetail).FirstOrDefaultAsync();
                if (entity != null)
                {
                    if (entity.UserDetail != null)
                    {
                        entity.UserDetail.FirstName = model.FirstName;
                        entity.UserDetail.LastModifiedBy = model.UpdatedBy;
                        entity.UserDetail.LastModifiedOn = DateTime.UtcNow;
                    }
                    entity.MobileNumber = model.MobileNumber;
                    entity.UserRoleId = model.RoleId ?? 0;
                    entity.UserEmail = model.UserEmail;
                    entity.LastModifiedBy = model.UpdatedBy;
                    entity.LastModifiedOn = DateTime.UtcNow;
                    entity.IsActive = model.IsActive;
                    try
                    {
                        await _user.Update(entity);
                    }
                    catch (Exception ex)
                    {
                        var exp = ex.InnerException;

                    }
                }
                return new UserUpdateOutputDto();
            }
        }

        public async Task<UserDeleteOutputDto> RemoveUserById(UserDeleteInputDto input)

        {
            var entity = await _user.GetById(input.Id);
            if (entity != null)
            {
                entity.DeleteReason = input.DeleteReason;
                entity.IsDeleted = true;
                entity.IsActive = false;
                entity.DeletedOn = DateTime.UtcNow;
                entity.DeletedBy = input.UserId;
                await _user.Update(entity);
                return new UserDeleteOutputDto()
                {
                    IsAdminUserDeleted = true,
                };
            }
            else
            {
                return new UserDeleteOutputDto();
            }
        }

    }
}
