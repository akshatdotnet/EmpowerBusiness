using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class UserOutputDTO
    {
        public List<UserDTO> List { get; set; } = new();
        public List<UserRoleDTO> RoleList { get; set; } = new();
        public UserInputDTO Input { get; set; } = new();

        public bool IsAddMode { get; set; } = false;
        public bool IsEditMode { get; set; } = false;
        public string SelectedFilter { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
    }

    public class UserInsertOutputDto
    {
        public bool UserEmailAlredyExist { get; set; } = false;
        public bool UserMobileAlredyExist { get; set; } = false;
    }
    public class UserUpdateOutputDto
    {
        public bool UserEmailAlredyExist { get; set; } = false;
        public bool UserMobileAlredyExist { get; set; } = false;
    }
    public class UserDeleteOutputDto
    {
        public bool IsAdminUserDeleted { get; set; } = false;
        public string? ErrorMessage { get; set; }
        public string? SuccessMessage { get; set; }
    }
    public class UserDeleteInputDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? DeleteReason { get; set; }
    }
}
