using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.Models.Constants;
using Empower.API;

namespace Empower.Models.API
{
    public class RegisterRequestDTO
    {
        [LocalizedRequired("SignUp.FirstName.Required")]
        public string FirstName { get; set; } = "";

        [LocalizedRequired("SignUp.LastName.Required")]
        [LocalizedMaxLength(UserConsts.MaxLastNameLength, "Common.MaxLength.Required")]
        [LocalizedMinLength(UserConsts.MinLastNameLength, "Common.MinLength.Required")]
        public string LastName { get; set; } = "";

        [LocalizedRequired("SignUp.Mobile.Required")]
        [LocalizedMaxLength(UserConsts.MaxMobileNumberLength, "SignUp.Mobile.MaxLength")]
        [LocalizedMinLength(UserConsts.MinMobileNumberLength, "SignUp.Mobile.MinLength.ErrorMsg")]
        [LocalizedRegExp(ApplicationRegExp.MobileNumber, "Common.Invalid.Mobile")]
        [DefaultValue("string")]
        public string Mobile { get; set; } = "";

        [LocalizedRequired("SignUp.Email.Required")]
        [LocalizedMaxLength(UserConsts.MaxUserEmailLength, "Common.MaxLength.Required")]
        [LocalizedMinLength(UserConsts.MinUserEmailLength, "Common.MinLength.Required")]
        [LocalizedRegExp(ApplicationRegExp.EmailAddress, "Common.Invalid.EmailAddess")]
        [DefaultValue("string")]
        public string EmailId { get; set; } = "";

        [LocalizedRequired("SignUp.Password.Required")]
        [DataType(DataType.Password)]
        [LocalizedMinLength(UserConsts.MinPasswordHashLength, "SignUp.Password.MinLength")]
        [LocalizedMaxLength(UserConsts.MaxPasswordHashLength, "SignUp.Password.MaxLength")]
        [LocalizedRegExp(ApplicationRegExp.Password, "SignUp.Password.MinLength.ErrorMsg")]
        [DefaultValue("string")]
        public string Password { get; set; } = "";

        [LocalizedCompare(nameof(Password), "SignUp.ReEnterPassword.Compare")]
        [LocalizedRequired("SignUp.ReEnterPassword.Required")]
        [LocalizedDisplay("SignUp.ReEnterPassword.Label")]
        [LocalizedMinLength(UserConsts.MinPasswordHashLength, "SignUp.ReEnterPassword.MinLength")]
        [LocalizedMaxLength(UserConsts.MaxPasswordHashLength, "SignUp.ReEnterPassword.MaxLength")]
        [DefaultValue("string")]
        public string ConfirmPassword { get; set; } = "";        

        
    }
}