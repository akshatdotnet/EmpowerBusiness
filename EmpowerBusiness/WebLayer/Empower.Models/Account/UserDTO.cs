using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MobileNumber { get; set; }
        public string UserEmail { get; set; } = "";
        public string? RoleName { get; set; }
        public string CreatedOn { get; set; } = "";
        public bool IsActive { get; set; }
        public string? LastLoggedIn { get; set; }
        public int? RoleId { get; set; }
    }
}
