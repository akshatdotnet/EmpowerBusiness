using Empower.Models.API;
using Empower.Models.Constants;
using Empower.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Empower.API.Controllers
{
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public string L(string key, params object[] args)
        {
            return LanguageConfigure.GetLocalizedValue(GlobalConstants.DefaultLanguageCode, key);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected JwtTokenData GetDataFromAccessToken()
        {
            // Retrieve the token from the HttpContext
            string accessToken = string.Empty;
            if (HttpContext == null)
            {
                return new JwtTokenData();
            }

            if (HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwt = tokenHandler.ReadJwtToken(accessToken);
                return new JwtTokenData()
                {
                    FirstName = jwt.Claims?.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.UniqueName)?.Value,
                    LastName = jwt.Claims?.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.FamilyName)?.Value,
                    Email = jwt.Claims?.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email)?.Value,
                    MobileNo = jwt.Claims?.FirstOrDefault(u => u.Type == ClaimTypes.MobilePhone)?.Value,
                    UserId = jwt.Claims?.FirstOrDefault(u => u.Type == "UserId")?.Value,
                    UserNameIdentifier = jwt.Claims?.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.NameId)?.Value
                };
            }
            else
            {
                return new JwtTokenData();
            }
        }


    }
}
