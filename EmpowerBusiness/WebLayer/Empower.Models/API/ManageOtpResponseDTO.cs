using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.API
{
    public class ManageOtpResponseDTO
    {
        public bool IsOtpVerified { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public bool IsOtpMatched { get; set; } = false;
        public int? UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string MessageOtpConfimation { get; set; } = string.Empty;
        public string SuccessMessage { get; set; } = string.Empty;
        public bool IsOtpSent { get; set; }
        public int OTPCode { get; set; }
        public string BinaryOTP { get; set; } = string.Empty;
    }
}
