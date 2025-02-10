using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class UserInputDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required."), Display(Name = "Name *", Prompt = "Enter Name")]
        //[InputMinLength(AdminUserConsts.MinNameLength, "Name should be at least {0} characters long.")]
        //[InputMaxLength(AdminUserConsts.MaxNameLength, "Name can not exceed {0} characters.")]
        //[InputAlphabetOnly("Only alphabets are allowed.")]
        public string FirstName { get; set; } = "";
        //[InputMaxLength(AdminUserConsts.MaxMobileNumberLength, "Mobile number can not exceed {0} characters.")]
        //[InputMinLength(AdminUserConsts.MinMobileNumberLength, "Mobile number should be at least {0} characters long.")]
        [Required(ErrorMessage = "Mobile number is required."), Display(Name = "Mobile Number *", Prompt = "Enter Mobile Number")]
        [RegularExpression(@"^[+-]?(?:\d+\d*|\d*\d+)[\r\n]*$", ErrorMessage = "Mobile number format is not valid.")]
        public string MobileNumber { get; set; } = "";

        [Required(ErrorMessage = "Email is required."), Display(Name = "Email Id *", Prompt = "Enter Email ID")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        //[InputMinLength(AdminUserConsts.MinUserEmailLength, "Email address should be at least  {0} characters long.")]
        //[InputMaxLength(AdminUserConsts.MaxUserEmailLength, "Email address can not exceed {0} characters.")]
        public string UserEmail { get; set; } = "";
        [Required(ErrorMessage = "User role is not selected."), Range(1, int.MaxValue, ErrorMessage = "User role is not selected.")]
        public int? RoleId { get; set; } = 0;
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string? ErrorMessage { get; set; }
        [Display(Name = "Activate/Deactivate")]
        public bool IsActive { get; set; } = true;
        public string Password { get; set; } = string.Empty;
        public List<UserRoleDTO> RoleList { get; set; } = new();
    }
}
