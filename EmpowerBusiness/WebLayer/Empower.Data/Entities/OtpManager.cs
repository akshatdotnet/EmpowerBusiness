using Empower.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Data.Entities
{
    [Table("OtpManagers")]
    public class OtpManager : FullAuditedEntity
    {
        public string? OtpMedia { get; set; }
        public bool IsOtpVarified { get; set; }
        public int Otp { get; set; }
        public string Token { get; set; } = string.Empty;
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
