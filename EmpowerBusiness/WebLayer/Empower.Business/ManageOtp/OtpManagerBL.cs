using Empower.Data.Entities;
using Empower.Data.Repository;
using Empower.Models.Account;
using Empower.Models.Enums;
using Empower.Models.ManageOtp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.ManageOtp
{
    internal class OtpManagerBL : IOtpManagerBL
    {
        private readonly IRepository<OtpManager> _otpManager;
        public OtpManagerBL(IRepository<OtpManager> otpManager)
        {
            _otpManager = otpManager;
        }
        public async Task<bool> CheckIsOtpVerifiedByToken(string token)
        {
            bool isVerified = false;
            var savedOtp = await _otpManager.FirstOrDefault(o => o.Token == token && o.IsOtpVarified && o.IsDeleted == false);
            if (savedOtp != null)
            {
                isVerified = true;
            }

            return isVerified;
        }

        public async Task<ManageOtpOutputDTO> CheckOtpByToken(string token, int otp)
        {
            var savedOtp = await _otpManager.FirstOrDefault(o => o.Token == token && o.Otp == otp && o.IsOtpVarified == false);
            ManageOtpOutputDTO manageOtpOutputDto = new();
            if (savedOtp != null)
            {
                manageOtpOutputDto.IsOtpMatched = true;
                manageOtpOutputDto.UserId = savedOtp.UserId;
            }
            return manageOtpOutputDto;
        }

        public async Task<ResndOtpOutputDTO?> GetMobileNumberByOtpToken(string token)
        {
            var savedOtp = await _otpManager.GetWhere(x => x.Token == token).FirstOrDefaultAsync();

            if (savedOtp != null)
            {
                return new ResndOtpOutputDTO()
                {
                    MobileNumber = (savedOtp.Mobile) ?? string.Empty,
                    Email = (savedOtp.Email) ?? string.Empty,
                    OTP = savedOtp.Otp
                };
            }
            return null;
        }

        public async Task<ManageOtpOutputDTO> InsertMobileOtp(ManageOtpInputDTO input)
        {
            var saveOtp = new OtpManager
            {
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                Mobile = input.Mobile,
                OtpMedia = input.OtpMedia,
                Otp = input.Otp,
                Email = input.Email,
                Token = Guid.NewGuid().ToString()
            };

            await _otpManager.Add(saveOtp);

            return new ManageOtpOutputDTO()
            {
                Token = saveOtp.Token
            };
        }

        public async Task<ManageOtpOutputDTO> InsertEmailOtp(ManageOtpInputDTO input)
        {
            var saveOtp = new OtpManager
            {
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                Email = input.Email,
                OtpMedia = input.OtpMedia,
                Otp = input.Otp,
                Token = Guid.NewGuid().ToString()
            };
            await _otpManager.Add(saveOtp);
            return new ManageOtpOutputDTO()
            {
                Token = saveOtp.Token
            };
        }

        public async Task<string> InsertOtp(int userId, int otp)
        {
            var saveOtp = new OtpManager
            {
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                Otp = otp,
                UserId = userId,
                Token = Guid.NewGuid().ToString()
            };
            await _otpManager.Add(saveOtp);
            return saveOtp.Token;
        }

        public async Task<bool> MarkOtpAsUsed(string token)
        {
            bool isUpdated = false;
            var savedOtp = await _otpManager.FirstOrDefault(o => o.Token == token);
            if (savedOtp != null)
            {
                savedOtp.IsOtpVarified = true;
                savedOtp.LastModifiedOn = DateTime.UtcNow;
                savedOtp.IsDeleted = false;
                await _otpManager.Update(savedOtp);
                isUpdated = savedOtp.IsOtpVarified;
            }

            return isUpdated;
        }

        public async Task<ManageOtpOutputDTO> SaveOtpForMailOrMobile(ForgotPasswordSendOtpInputDTO input)
        {
            var saveOtp = new OtpManager
            {
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                Mobile = OtpMediaEnum.MobileOtpMedia == input.OtpMedia ? input.EmailMobile : "",
                OtpMedia = input.OtpMedia,
                Otp = input.Otp ?? 0,
                Email = OtpMediaEnum.EmailOtpMedia == input.OtpMedia ? input.EmailMobile : "",
                Token = Guid.NewGuid().ToString()
            };

            await _otpManager.Add(saveOtp);

            return new ManageOtpOutputDTO()
            {
                Token = saveOtp.Token
            };
        }
    }
}
