using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.API
{
    public class JwtTokenData
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? MobileNo { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? UserId { get; set; } = string.Empty;
        public string? UserNameIdentifier { get; set; } = string.Empty;
    }
}
