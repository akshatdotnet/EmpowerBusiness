using Empower.API;
using Empower.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Account
{
    public class SignUpInputDTO
    {
        public int CustomerId { get; set; }
        //[LocalizedRequired("SignUp.FirstName.Required")]
        //[LocalizedDisplay("SignUp.FirstName.Label")]
        //[LocalizedMaxLength(UserConsts.MaxFirstNameLength, "Common.MaxLength.Required")]
        //[LocalizedMinLength(UserConsts.MinFirstNameLength, "Common.MinLength.Required")]

        public string FirstName { get; set; } = "";

        //[LocalizedRequired("SignUp.LastName.Required")]
        //[LocalizedDisplay("SignUp.LastName.Label")]
        //[LocalizedMaxLength(UserConsts.MaxLastNameLength, "Common.MaxLength.Required")]
        //[LocalizedMinLength(UserConsts.MinLastNameLength, "Common.MinLength.Required")]
        public string LastName { get; set; } = "";

        [LocalizedRequired("SignUp.Mobile.Required")]
        [LocalizedDisplay("SignUp.Mobile.Label")]
        [LocalizedMaxLength(UserConsts.MaxMobileNumberLength, "SignUp.Mobile.MaxLength")]
        [LocalizedMinLength(UserConsts.MinMobileNumberLength, "SignUp.Mobile.MinLength.ErrorMsg")]
        [LocalizedRegExp(ApplicationRegExp.MobileNumber, "Common.Invalid.Mobile")]
        public string Mobile { get; set; } = "";

        //[LocalizedRequired("SignUp.Email.Required")]
        //[LocalizedDisplay("SignUp.Email.Label")]
        //[LocalizedMaxLength(UserConsts.MaxUserEmailLength, "Common.MaxLength.Required")]
        //[LocalizedMinLength(UserConsts.MinUserEmailLength, "Common.MinLength.Required")]
        //[LocalizedRegExp(ApplicationRegExp.EmailAddress, "Common.Invalid.EmailAddess")]
        public string EmailId { get; set; } = "";

        //[LocalizedRequired("SignUp.Password.Required")]
        //[LocalizedDisplay("SignUp.Password.Label")]
        [DataType(DataType.Password)]
        //[LocalizedMinLength(UserConsts.MinPasswordHashLength, "SignUp.Password.MinLength")]
        //[LocalizedMaxLength(UserConsts.MaxPasswordHashLength, "SignUp.Password.MaxLength")]
        //[LocalizedRegExp(ApplicationRegExp.Password, "SignUp.Password.MinLength.ErrorMsg")]
        public string Password { get; set; } = "";

        //[LocalizedCompare(nameof(Password), "SignUp.ReEnterPassword.Compare")]
        
        //[LocalizedRequired("SignUp.ReEnterPassword.Required")]
        //[LocalizedDisplay("SignUp.ReEnterPassword.Label")]
        //[LocalizedMinLength(UserConsts.MinPasswordHashLength, "SignUp.ReEnterPassword.MinLength")]
        //[LocalizedMaxLength(UserConsts.MaxPasswordHashLength, "SignUp.ReEnterPassword.MaxLength")]
        public string ConfirmPassword { get; set; } = "";
        public int? CreatedBy { get; set; }
        public bool IsOtpSend { get; set; } = false;
        public string? VerifySmsOtpTokenValue { get; set; }
        public string? ErrorMobileExists { get; set; }
        public string ErrorEmailExists { get; set; } = string.Empty;
        public string? MessageOtpConfirmationMsg { get; set; }
    }
}
