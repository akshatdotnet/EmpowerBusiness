using Empower.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class ForgotPasswordSendOtpInputDTO
    {
        [Required(ErrorMessage = "Email/Mobile is required.")]
        [LocalizedMinLengthAttribute(UserConsts.MinMobileNumberLength, "Email/Mobile should be at least {0} characters long.")]
        public string EmailMobile { get; set; } = string.Empty;
        public int? Otp { get; set; }
        public string? OtpMedia { get; set; } = string.Empty;
    }
}
