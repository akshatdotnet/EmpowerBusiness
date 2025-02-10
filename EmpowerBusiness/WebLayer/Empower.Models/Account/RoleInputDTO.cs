using Empower.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class RoleInputDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        [Display(Name = "Role Name *", Prompt = "Enter Role Name")]
        //[InputMaxLength(UserRoleConsts.MaxRoleNameLength, "The role name cannot exceed {0} characters.")]
        //[InputMinLength(AdminUserRoleConsts.MinRoleNameLength, "The role name must be at least of {0} characters long.")]
        //[InputAlphabetOnly("Only alphabets are allowed.")]
        public string Name { get; set; } = "";
        //[Required(ErrorMessage = "Description is required.")]
        //[InputMaxLength(AdminUserRoleConsts.MaxRoleDescriptionLength, "The description cannot exceed {0} characters.")]
        //[InputMinLength(AdminUserRoleConsts.MinRoleDescriptionLength, "The description must be at least of {0} characters long.")]
        //[Display(Name = "Description *", Prompt = "Enter Description")]
        public string Description { get; set; } = "";

        public string? ErrorMessage { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
