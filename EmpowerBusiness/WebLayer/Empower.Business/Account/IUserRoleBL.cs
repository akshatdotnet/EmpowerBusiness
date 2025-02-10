using Empower.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.Account
{
    public interface IUserRoleBL
    {
        Task<List<RoleDTO>> GetAllRole();
        Task<RoleOutputDTO> GetAllAdminRole(string filter = "");
        Task<RoleDTO?> GetAdminRoleById(int id);
        Task<bool> IsAdminRoleNameExist(string name, int id = 0);
        Task<RoleInsertOutputDTO> InsertAdminRole(RoleInputDTO model);
        Task<RoleUpdateOutputDTO> UpdateAdminRole(RoleInputDTO model);
        Task<RoleDeleteOutputDTO> RemoveAdminRoleById(int id, int deletedBy);
    }
}
