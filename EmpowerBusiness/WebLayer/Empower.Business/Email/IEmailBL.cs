
using Empower.Models.Account;
using Empower.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.Email
{
    public interface IEmailBL
    {
        Task<MailRequestOutputDTO> SendCustomerCredentialMail(SignUpInputDTO model);
        Task<MailRequestOutputDTO> SendUserResetPasswordEmail(string toEmail, string callBackUrl);
        Task<SendOtpToEmailOutputDTO> SendEmailSignUpOtp(int otp, string email);
        Task<MailRequestOutputDTO> SendCommonEmail(MailRequestInputDTO mailRequestInputDto);
    }
}
