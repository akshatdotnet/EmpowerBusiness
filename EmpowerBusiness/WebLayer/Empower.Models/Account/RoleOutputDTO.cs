using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class RoleOutputDTO
    {
        public List<RoleDTO> RoleList { get; set; } = new();
        public List<RoleDTO> SerachFilter { get; set; } = new();
        public RoleInputDTO Input { get; set; } = new();

        public bool IsAddMode { get; set; } = false;
        public bool IsEditMode { get; set; } = false;
        public string SelectedFilterRole { get; set; } = "";
        public string ErrorMessage { get; set; } = "";

    }

    public class RoleInsertOutputDTO
    {
        public bool IsUserRoleNameExist { get; set; } = false;
    }

    public class RoleUpdateOutputDTO
    {
        public bool IsUserRoleNameExist { get; set; } = false;
    }
    public class RoleDeleteOutputDTO
    {
        public bool IsRoleAssociatedToUser { get; set; } = false;
    }
}
