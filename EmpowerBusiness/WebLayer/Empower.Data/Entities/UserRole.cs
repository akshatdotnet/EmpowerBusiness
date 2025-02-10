using Empower.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.Models.Constants;

namespace Empower.Data.Entities
{
    [Table("UserRoles")]
    public class UserRole : FullAuditedEntity
    {

        [StringLength(UserRoleConsts.MaxRoleNameLength)]
        public string Name { get; set; } = string.Empty;

        [StringLength(UserRoleConsts.MaxRoleDescriptionLength)]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserRolePermission> UserRoleClaims { get; set; } = new List<UserRolePermission>();

    }
}
