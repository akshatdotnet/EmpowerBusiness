using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class SignUpOutputDTO
    {
        public bool MobileNumberAlredyUsed { get; set; }
        public bool EmailAlredyUsed { get; set; }
        public int UserId { get; set; } = 0;
    }
}
