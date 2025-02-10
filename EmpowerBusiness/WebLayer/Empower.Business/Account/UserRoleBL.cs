using Empower.Data.Entities;
using Empower.Data.Repository;
using Empower.Models.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.Account
{
    internal class UserRoleBL : IUserRoleBL
    {
        private readonly IRepository<UserRole> _adminRole;
        private readonly IRepository<User> _adminUser;
        public UserRoleBL(
            IRepository<UserRole> adminRole, IRepository<User> adminUser
            ) 
        {
            _adminRole = adminRole;
            _adminUser = adminUser;
        }
        public async Task<RoleDTO?> GetAdminRoleById(int id)
        {
            var result = await _adminRole.GetById(id);
            if (result != null)
            {
                return new RoleDTO()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description
                };
            }
            return null;
        }

        public async Task<RoleOutputDTO> GetAllAdminRole(string filter = "")
        {
            var model = new RoleOutputDTO()
            {
                IsAddMode = false,
                IsEditMode = false,
                SelectedFilterRole = ""
            };
            var result = await GetAllRole();
            model.SerachFilter = result;
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                model.SerachFilter = result.Where(x =>
                (x.Name ?? "").ToLower().Contains(filter) ||
                (x.Description ?? "").ToLower().Contains(filter) ||
                (x.CreatedOn ?? "").Contains(filter)
                ).ToList();

            }
            return model;
        }

        public async Task<List<RoleDTO>> GetAllRole()
        {
            var result = await _adminRole.GetWhere(x => x.IsDeleted == false && x.IsActive == true).ToListAsync();
            return result.Select(x => new RoleDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedOn = x.CreatedOn.ToGlobalDateFormatWithTime(),
            }).ToList();
        }

        public async Task<RoleInsertOutputDTO> InsertAdminRole(RoleInputDTO model)
        {
            if (await IsAdminRoleNameExist(model.Name, 0))
            {
                return new RoleInsertOutputDTO()
                {
                    IsUserRoleNameExist = true
                };
            }
            else
            {
                await _adminRole.Add(new UserRole()
                {

                    Name = model.Name,
                    Description = model.Description,
                    CreatedBy = model.CreatedBy,
                    IsActive = true,
                    IsDeleted = false
                });
                return new RoleInsertOutputDTO();
            }
        }

        public async Task<bool> IsAdminRoleNameExist(string name, int id = 0)
        {
            bool isExist = false;
            if (!string.IsNullOrEmpty(name))
            {
                if (id > 0)
                {
                    //Edit Case
                    isExist = _adminRole.Any(x => x.Id != id && x.Name.ToLower() == name.ToLower() && x.IsActive == true && x.IsDeleted == false);
                }
                else
                {
                    //Add Case
                    isExist = _adminRole.Any(x => x.Name.ToLower() == name.ToLower() && x.IsActive == true && x.IsDeleted == false);
                }
            }
            return await Task.FromResult(isExist);
        }

        public async Task<RoleDeleteOutputDTO> RemoveAdminRoleById(int id, int deletedBy)
        {
            var result = await _adminUser.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                return new RoleDeleteOutputDTO()
                {
                    IsRoleAssociatedToUser = true,
                };
            }
            var entity = await _adminRole.GetById(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.IsActive = false;
                entity.DeletedOn = DateTime.UtcNow;
                entity.DeletedBy = deletedBy;
                await _adminRole.Update(entity);
            }
            return new RoleDeleteOutputDTO();
        }

        public async Task<RoleUpdateOutputDTO> UpdateAdminRole(RoleInputDTO model)
        {
            if (await IsAdminRoleNameExist(model.Name, model.Id))
            {
                return new RoleUpdateOutputDTO() { IsUserRoleNameExist = true };
            }
            else
            {
                var entity = await _adminRole.GetById(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.LastModifiedBy = model.UpdatedBy;
                    entity.LastModifiedOn = DateTime.UtcNow;
                    await _adminRole.Update(entity);

                }
                return new RoleUpdateOutputDTO();
            }
        }
    }

}
