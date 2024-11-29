using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class ForgotPasswordDTO
    {
        [Required(ErrorMessage = "Please enter email id.")]
        [Display(Name = "Email ID", Prompt = "Enter user email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(30, ErrorMessage = "User email must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string UserEmail { get; set; } = string.Empty;

        public bool EmailSent { get; set; } = false;
    }
}
