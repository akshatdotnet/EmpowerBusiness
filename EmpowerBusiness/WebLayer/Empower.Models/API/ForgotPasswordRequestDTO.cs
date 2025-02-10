using Empower.API;
using Empower.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.API
{
    public class ForgotPasswordRequestDTO
    {
        [LocalizedRequired("SignUp.Email.Required")]
        [LocalizedDisplay("SignUp.Email.Label")]
        [LocalizedMaxLength(UserConsts.MaxUserEmailLength, "Common.MaxLength.Required")]
        [LocalizedMinLength(UserConsts.MinUserEmailLength, "Common.MinLength.Required")]
        [LocalizedRegExp(ApplicationRegExp.EmailAddress, "Common.Invalid.EmailAddess")]
        [DefaultValue("string")]
        public string EmailId { get; set; } = string.Empty;
    }
}
