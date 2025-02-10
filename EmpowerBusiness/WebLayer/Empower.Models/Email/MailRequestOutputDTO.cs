using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Email
{
    public class MailRequestOutputDTO
    {
        public string ErrorMessage { get; set; } = String.Empty;
        public bool IsError { get; set; }
    }
}
