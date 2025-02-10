using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.API
{
    public class ManageOtpRequestDTO
    {
        public int Otp { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string OtpMedia { get; set; } = string.Empty;
    }
}
