using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.AppSettings
{
    public class EmailSetting
    {
        public string SenderEmailId { get; set; } = string.Empty;
        public string SenderDisplayName { get; set; } = string.Empty;
        public string SmtpPassword { get; set; } = string.Empty;
        public string SmtpHost { get; set; } = string.Empty;
        public int SmtpPort { get; set; }
    }
}
