using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.API
{
    public class LoginRequestDTO
    {
        [LocalizedRequired("Login.EmailMobile.Required")]
        public string Email { get; set; } = string.Empty;

        [LocalizedRequired("Login.Password.Required")]
        public string Password { get; set; } = string.Empty;

        [LocalizedRequired("Login.DeviceId.Required")]
        public string DeviceId { get; set; }
    }
}
