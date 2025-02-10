using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.Data.Entities.Base;
using Empower.Models.Constants;

namespace Empower.Data.Entities
{
    [Table("Users")]
    public class User : FullAuditedEntity
    {

        [StringLength(UserConsts.MaxUserNameLength)]
        public string UserName { get; set; } = string.Empty;

        [StringLength(UserConsts.MaxUserEmailLength)]
        public string UserEmail { get; set; } = string.Empty;
        
        [StringLength(UserConsts.MaxPasswordHashLength)]
        public string? PasswordHash { get; set; }

        public string? DeleteReason { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailVerified { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public string? ResetPasswordToken { get; set; }

        public DateTime? LastResetPasswordCreatedDate { get; set; }
        public bool IsSocialMediaUser { get; set; } = false;

        [StringLength(UserConsts.MaxMobileNumberLength)]
        public string? MobileNumber { get; set; }
        
        public UserDetail? UserDetail { get; set; }
        public UserRole? UserRole { get; set; }
        public int UserRoleId { get; set; } = 0;

    }
}
