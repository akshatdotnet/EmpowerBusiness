﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class LoginInputDTO
    {

        [Required(ErrorMessage = "Please enter email id.")]
        [Display(Name = "Email ID", Prompt = "Enter User Email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(30, ErrorMessage = "User Email must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string UserEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter password.")]
        //[StringLength(8, ErrorMessage = "Only 8 characters allowed")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter Password")]
        [StringLength(20, ErrorMessage = "Password must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnURL { get; set; } = @"/";
    }
}