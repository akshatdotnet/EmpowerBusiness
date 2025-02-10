using AutoMapper;
using Azure;
using Empower.API.Models;
using Empower.Business;
using Empower.Business.Account;
using Empower.Business.Email;
using Empower.Business.ManageOtp;
using Empower.Business.MyPreference;
using Empower.Business.Wallet;
using Empower.Models.Account;
using Empower.Models.API;
using Empower.Models.ManageOtp;
using Empower.Models.MyPreference;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Empower.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountBL _serviceUser;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        private readonly IMyPreferenceBL _serviceMyPreference;
        private readonly IWalletBL _walletBL;
        private readonly ApiSettings _apiSettings;
        private readonly IEmailBL _serviceEmail;
        private readonly Domains _domains;
        private readonly IOtpManagerBL _serviceOtpManager;

        public AccountController(
            IAccountBL accountService, 
            ILogger<AccountController> logger,
            IWalletBL walletBL,
            IMapper mapper,
            IOptions<ApiSettings> apiSettings,
            IEmailBL serviceEmail,
            IOptions<Domains> domains,
            IOtpManagerBL serviceOtpManager,
        IMyPreferenceBL serviceMyPreference
            )
        {
            _serviceUser = accountService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _response = new();
            _walletBL = walletBL;
            _apiSettings = apiSettings.Value;
            _mapper = mapper;
            _serviceMyPreference = serviceMyPreference;
            _serviceEmail = serviceEmail;
            _serviceOtpManager = serviceOtpManager;
            _domains = domains.Value;
        }

        #region Login

        /// <summary>
        /// To get the token with user's basic details
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Account/Login
        ///     {
        ///       "emailMobile": "test@2gmail.cm",
        ///       "password": "test",
        ///       "deviceId": "Samsung-XE56"
        ///     }
        /// </remarks>
        /// <param name="req"></param>
        /// <response code="200">On successful login returns Token with user's basic details</response>
        /// <response code="400">If invalid request body pass</response>
        /// <response code="401">If user is inactive</response>
        /// <response code="500">Something went wrong on server</response>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDTO req)
        {
            if (ModelState.IsValid)
            {
                var user = await _serviceUser.GetValidUser(_mapper.Map<LoginInputDTO>(req));

                if (user == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Username or password is incorrect");
                    return BadRequest(_response);
                }

                if (!user.IsActive)
                {
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("User is inactive");
                    return Unauthorized(_response);
                }

                var result = _mapper.Map<LoginResponseDTO>(user);
                result.Token = GetAccessToken(user);

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = result;

                return Ok(_response);
            }
            else
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ValidationMessages = _response.GetErrorsFromModelState(ModelState);
                return BadRequest(_response);
            }
        }

        #endregion

        #region Registration
        /// <summary>
        /// To sign up new user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Account/Register
        ///     {
        ///         "firstName": "string",
        ///         "lastName": "string",
        ///         "mobile": "string",
        ///         "emailId": "string",
        ///         "password": "string",
        ///         "confirmPassword": "string"
        ///     }
        /// </remarks>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <response code="201">Registration process done successfully</response>
        /// <response code="400">If invalid request body pass</response>
        /// <response code="409">If user information is already exist</response>
        /// <response code="500">Something went wrong on server</response>
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Register(RegisterRequestDTO req)
        {
            
            #region Custom Validation
            if (req.Password != req.ConfirmPassword)
            {   
                ModelState.AddModelError("ConfirmPassword", ("SignUp.ReEnterPassword.Compare"));
            }
            #endregion

            if (ModelState.IsValid)
            {
                var result = await _serviceUser.AddUser(_mapper.Map<SignUpInputDTO>(req));

            if (result.MobileNumberAlredyUsed)
            {
                ModelState.AddModelError(nameof(req.Mobile), L("Common.Mobile.AlreadyExists"));
                _response.StatusCode = HttpStatusCode.Conflict;
                _response.IsSuccess = false;
                _response.ValidationMessages = _response.GetErrorsFromModelState(ModelState);
                return Conflict(_response);
            }

            if (result.EmailAlredyUsed)
            {
                ModelState.AddModelError(nameof(req.EmailId), L("Common.Email.AlreadyExists"));
                _response.StatusCode = HttpStatusCode.Conflict;
                _response.IsSuccess = false;
                _response.ValidationMessages = _response.GetErrorsFromModelState(ModelState);
                return Conflict(_response);
            }

            if (result.UserId > 0)
            {
                var defaultPreference = await _serviceMyPreference.GetDefaultPreference();
                MyPreferenceInputDTO myPreferenceInputDto = new()
                {
                    CountryMasterId = defaultPreference.CountryMasterId,
                    CurrencyMasterId = defaultPreference.CurrencyMasterId,
                    MeasurementMasterId = defaultPreference.MeasurementMasterId,
                    PreferredLanguage = defaultPreference.PreferredLanguage,
                    UserId = result.UserId,
                };
                var addUpdateResult = await _serviceMyPreference.InsertUpdatePreference(myPreferenceInputDto);
                await _walletBL.CreateWallet(new Empower.Data.Entities.Wallet()
                {
                    UserId = result.UserId,
                    Balance = 0
                }, result.UserId);

                var sendMail = await _serviceEmail.SendCustomerCredentialMail(_mapper.Map<SignUpInputDTO>(req));

                _response.Result = new
                {
                    Message = @L("Congratulations.Message.Message")
                };
                _response.StatusCode = HttpStatusCode.Created;
                return StatusCode((int)HttpStatusCode.Created, _response);

            }
            else
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { L("SignUp.NewCustomer.UnableToCreate") };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }
            else
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ValidationMessages = _response.GetErrorsFromModelState(ModelState);
                return BadRequest(_response);
    }
}

        #endregion


        #region Forgot Password
        /// <summary>
        /// Use to recover an account
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Account/ForgotPassword
        ///     {
        ///         "emailId": "string"
        ///     }
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">On successful, email is sent to the user with reset password link</response>
        /// <response code="400">Invalid data passed</response>
        /// <response code="500">Something went wrong on server</response>
        [HttpPost("ForgotPassword")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordRequestDTO req)
        {
            //return Ok();
            if (ModelState.IsValid)
            {
                var resetPasswordToken = await _serviceUser.GenerateUserForgotPasswordToken(req.EmailId);
                if (string.IsNullOrEmpty(resetPasswordToken))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { L("ForgotPassword.Invaild.Email") };
                    return BadRequest(_response);
                }
               else
               {
                   //Sending token to user to detect the valid link and user
                   var callbackUrl = $"{_domains.CustomerPortal}/Account/ResetPassword?token={resetPasswordToken}";
                   //Send Email
                   await _serviceEmail.SendUserResetPasswordEmail(req.EmailId, callbackUrl ?? "");
                   //Send SMS
                   //var getNumber = await _serviceUser.GetUserbyEmail(req.EmailId);
                   //if (getNumber != null)
                   //{
                   //    await _serviceSms.SendSmsForResetPassword(callbackUrl ?? "", getNumber.MobileNo);
                   //}
           
                   _response.StatusCode = HttpStatusCode.OK;
                   _response.Result = new
                   {
                       Message = L("ResetPassword.LinkSend.SuccessMsg"),
                       ResetPasswordLink = callbackUrl ?? ""
                   };
                   return Ok(_response);
               }
           }
           else
           {
               _response.StatusCode = HttpStatusCode.BadRequest;
               _response.IsSuccess = false;
               _response.ValidationMessages = _response.GetErrorsFromModelState(ModelState);
               return BadRequest(_response);
           }
        }

        #endregion


        #region OTP

        /// <summary>
        /// Use to send otp
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Account/SendOTP
        ///     {
        ///        "mobile": "string",
        ///        "email": "string"
        ///     }
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">On successful, an otp will send on the email and mobile number</response>
        /// <response code="400">Invalid data passed</response>
        /// <response code="500">Something went wrong on server</response>
        [HttpPost("SendOTP")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> SendOTP(ManageOtpRequestDTO req)
        {
            
             #region Custom Validation
             if (string.IsNullOrEmpty(req.Email))
                 ModelState.AddModelError("Email", L("Api.Common.EmailRequired"));
             if (string.IsNullOrEmpty(req.Mobile))
                 ModelState.AddModelError("Mobile", L("Api.Common.PhoneRequired"));
            #endregion

             if (ModelState.IsValid)
             {
                 ManageOtpResponseDTO res = new()
                 {
                     IsOtpVerified = false,
                     ErrorMessage = ""
                 };
                 var isMobileExist = await _serviceUser.IsUserMobileExist(req.Mobile);
                 if (isMobileExist)
                 {
                     _response.StatusCode = HttpStatusCode.BadRequest;
                     _response.IsSuccess = false;
                     _response.ErrorMessages = new List<string>() { L("Common.Mobile.AlreadyExists") };
                     return BadRequest(_response);
                 }
            
                 var isEmailExist = await _serviceUser.IsUserEmailExist(req.Email);
                 if (isEmailExist)
                 {
                     _response.StatusCode = HttpStatusCode.BadRequest;
                     _response.IsSuccess = false;
                     _response.ErrorMessages = new List<string>() { L("Common.Email.AlreadyExists") };
                     return BadRequest(_response);
                 }
                 var otp = Randomize.GenerateRandomOTP();                 
                 //var smsResult = await _serviceSms.SendMobileSignUpOtp(otp, req.Mobile);
                 //var emailResult = await _serviceEmail.SendOtp(string.Format(ApplicationConstants.SignUpVerifyOtpMessage, otp), model.Email, ApplicationConstants.SignUpVerifyOtpEmailSubject);
                 var emailResult = await _serviceEmail.SendEmailSignUpOtp(otp, req.Email);
                //res.IsOtpSent = smsResult.IsSmsSent || emailResult.IsOtpSent;
                //if (smsResult.IsSmsSent || emailResult.IsOtpSent)
                if (emailResult.IsOtpSent)
                {
                     req.Otp = otp;
                     req.OtpMedia = ApplicationConstants.MobileOtpMedia;
                     req.Email = req.Email;
                     var result = await _serviceOtpManager.InsertMobileOtp(_mapper.Map<ManageOtpInputDTO>(req));
                     if (result != null)
                     {
                         var byteOTP = string.Empty;
                         byte[] otpBytes = System.Text.Encoding.ASCII.GetBytes(otp.ToString());
                         foreach (var b in otpBytes)
                         {
                             byteOTP += Convert.ToString(b, 2).PadLeft(8, '0');
                         }
                         res.Token = result.Token;
                         res.OTPCode = otp;
                         res.BinaryOTP = byteOTP.ToString();
                         _response.StatusCode = HttpStatusCode.OK;
                         res.SuccessMessage = L("Api.Otp.SentSucessfully");
                         _response.Result = res;
                     }
                     else
                     {
                         res.ErrorMessage = L("SignUp.NewCustomer.UnableToSaveOtp");
                     }
            
                 }
                 //if (!smsResult.IsSmsSent)
                 //{
                 //    res.ErrorMessage = L("SignUp.NewCustomer.OtpSendFail") + ". ";
                 //}
                 if (!emailResult.IsOtpSent)
                 {
                     res.ErrorMessage += L("SignUp.NewCustomer.OtpSendFailEmail");
                 }
                 if (!string.IsNullOrEmpty(res.ErrorMessage))
                 {
                     _response.StatusCode = HttpStatusCode.BadRequest;
                     _response.IsSuccess = false;
                     return BadRequest(_response);
                 }
                 return Ok(_response);
             }
             else
             {
                 _response.StatusCode = HttpStatusCode.BadRequest;
                 _response.IsSuccess = false;
                 _response.ValidationMessages = _response.GetErrorsFromModelState(ModelState);
                 return BadRequest(_response);
             }
        }

        /// <summary>
        /// Use to verify otp
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Account/VerifyOTP
        ///     {
        ///        "otp": 0,
        ///        "token": "string"       
        ///     }
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">On successful, otp verification message will be sent</response>
        /// <response code="400">Invalid data passed</response>
        /// <response code="500">Something went wrong on server</response>
        [HttpPost("VerifyOTP")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> VerifyOTP(ManageOtpRequestDTO req)
        {
            
            #region Custom Validation
            if (string.IsNullOrEmpty(req.Token))
                ModelState.AddModelError("Token", L("Api.Common.TokenRequired"));
            if (req.Otp <= 0)
                ModelState.AddModelError("Otp", L("Api.Common.OTPRequired"));

            #endregion
            if (ModelState.IsValid)
            {
                var res = new ManageOtpResponseDTO()
                {
                    IsOtpVerified = false,
                    ErrorMessage = ""
                };
                var result = await _serviceOtpManager.CheckOtpByToken(req.Token, req.Otp);
                if (result.IsOtpMatched)
                {
                    res.IsOtpVerified = true;
                    //activate the user
                    if (result.UserId.HasValue)
                        await _serviceUser.MarkUserActive(result.UserId.Value);
                    await _serviceOtpManager.MarkOtpAsUsed(req.Token);
                    _response.StatusCode = HttpStatusCode.OK;
                    res.SuccessMessage = L("Common.OtpVerified.Success");
                    _response.Result = res;
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { L("MyProfile.InvaildOtp") };
                    return BadRequest(_response);
                }
                return Ok(_response);
            }
            else
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ValidationMessages = _response.GetErrorsFromModelState(ModelState);
                return BadRequest(_response);
            }
        }

        #endregion


        #region Reset Password
        [HttpGet("ResetPassword")]        
        public async Task<IActionResult> ResetPassword(string token)
        {

            return Ok("Thank you your ResetPassword is processing.");

            //if (await _serviceUser.IsResetPasswordTokenValid(token))
            //{
            //    var model = new ResetPasswordInputDTO { Token = token };
            //    return View(model);
            //}
            //else
            //{
            //    Danger(L("ResetPassword.Link.ExpireOrInvalid"));
            //    return RedirectToAction(nameof(Login));
            //}

        }

        #endregion

        #region Private methods
        private string GetAccessToken(LoginOutputDTO user)
        {
            //var keysecret = "VBwLjdy8SGM4NmWcHOJyX7BGl8R52ZiM9mltjgTmBfsREJMe3J5GSvm3mqaDEsJqmZRrx3rpCDNPLn5FLJ2ArtfKl4EeLAVG6mX3";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_apiSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                               new Claim(ClaimTypes.Name, user.FirstName.ToString()),
                               new Claim(ClaimTypes.Surname, user.LastName.ToString()),
                               new Claim(ClaimTypes.MobilePhone, user.MobileNo.ToString()),
                               new Claim(ClaimTypes.Email, user.UserEmail.ToString()),
                               new Claim("UserId", user.Id.ToString()),
                               new Claim(ClaimTypes.NameIdentifier, user.UniqueId.ToString()),
                }),
                Issuer = _apiSettings.Issuer,
                Expires = DateTime.UtcNow.AddDays(_apiSettings.TokenLife),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }        

        #endregion

    }
}
