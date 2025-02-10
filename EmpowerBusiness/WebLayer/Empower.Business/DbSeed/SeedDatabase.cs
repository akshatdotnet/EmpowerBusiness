using Empower.Data.Entities;
using Empower.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.DbSeed
{
    internal class SeedDatabase : ISeedDatabase
    {
        private readonly IRepository<User> _user;

        public SeedDatabase(
        IRepository<User> user
            )
        {
            _user = user;
        }
        public async Task SeedMasterData()
        {
            await AddUsers();
        }

        private async Task AddUsers()
        {
            string encryptedDBPassword = EncryptDecrypt.Encrypt("Admin@123");
            //if (!_user.Any())
            //{
            //    await _user.Add(new User
            //    {
            //        IsActive = true,
            //        UserEmail = "tom@mailinator.com",
            //        PasswordHash = encryptedDBPassword,
            //        IsEmailVerified = true,
            //        UserDetail = new UserDetail
            //        {
            //            FirstName = "Tom",
            //            LastName = "Cruise"
            //        }
            //    });
            //}

            if (!_user.Any())
            {
                await _user.Add(new User
                {
                    IsActive = true,
                    UserEmail = "super@intelegain.com",
                    UserName = "super",
                    PasswordHash = encryptedDBPassword,
                    IsEmailVerified = true,
                    UserDetail = new UserDetail
                    {
                        FirstName = "super",
                        LastName = "admin"
                    },
                    UserRole = new UserRole()
                    {
                        Name = "Admin",
                        Description = "Admin user role",
                        IsActive = true,
                        UserRoleClaims = PermissionConfigure.GetSystemModules(true).Select(x => new UserRolePermission()
                        {
                            ControllerName = x.Controller,
                            ModuleName = x.Name,
                            AllowView = true,
                            AllowDelete = true,
                            AllowEdit = true,
                            AllowAdd = true
                        }).ToList()
                    
                    }
                });




            }

        }
        }
}
