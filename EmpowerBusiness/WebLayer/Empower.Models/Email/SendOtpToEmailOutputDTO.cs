using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Email
{
    public class SendOtpToEmailOutputDTO
    {
        public bool IsOtpSent { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
