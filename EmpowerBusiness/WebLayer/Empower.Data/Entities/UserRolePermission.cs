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
    [Table("UserRolePermissions")]
    public class UserRolePermission : FullAuditedEntity
    {
        public int UserRoleId { get; set; }
        [StringLength(UserRolePermissionConsts.MaxRoleControllerNameLength)]
        public string ControllerName { get; set; } = string.Empty;

        [StringLength(UserRolePermissionConsts.MaxRoleModuleNameLength)]
        public string ModuleName { get; set; } = string.Empty;
        public bool AllowAdd { get; set; } = false;
        public bool AllowEdit { get; set; } = false;
        public bool AllowDelete { get; set; } = false;
        public bool AllowView { get; set; } = false;
        public UserRole? UserRole { get; set; }
    }
}
