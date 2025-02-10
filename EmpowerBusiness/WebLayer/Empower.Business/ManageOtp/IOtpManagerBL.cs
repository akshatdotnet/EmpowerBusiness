using Empower.Models.Account;
using Empower.Models.ManageOtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.ManageOtp
{
    public interface IOtpManagerBL
    {
        Task<string> InsertOtp(int userId, int otp);
        Task<bool> MarkOtpAsUsed(string token);
        Task<ManageOtpOutputDTO> CheckOtpByToken(string token, int otp);
        Task<bool> CheckIsOtpVerifiedByToken(string token);
        Task<ResndOtpOutputDTO?> GetMobileNumberByOtpToken(string token);
        Task<ManageOtpOutputDTO> InsertMobileOtp(ManageOtpInputDTO input);
        Task<ManageOtpOutputDTO> InsertEmailOtp(ManageOtpInputDTO input);
        Task<ManageOtpOutputDTO> SaveOtpForMailOrMobile(ForgotPasswordSendOtpInputDTO input);
    }
}
