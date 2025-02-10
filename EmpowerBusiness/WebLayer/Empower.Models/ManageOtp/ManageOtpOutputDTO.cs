using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.ManageOtp
{
    public class ManageOtpOutputDTO
    {
        public bool IsOtpVerified { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public bool IsOtpMatched { get; set; } = false;
        public int? UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string MessageOtpConfimation { get; set; } = string.Empty;
        public string SuccessMessage { get; set; } = string.Empty;
        public bool IsOtpSent { get; set; }
    }

    public class ResndOtpOutputDTO
    {
        public string MobileNumber { get; set; } = string.Empty;
        public int OTP { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
