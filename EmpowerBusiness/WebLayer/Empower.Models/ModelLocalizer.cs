using Empower.Models.Constants;
using Empower.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models
{
    public static class ModelLocalizer
    {
        private static IHttpContextAccessor? _httpContextAccessor = null;
        private static string _cookieLanguageKey = string.Empty;

        public static void Configure(IHttpContextAccessor? httpContextAccessors, string CookieLanguageKey)
        {
            _httpContextAccessor = httpContextAccessors;
            _cookieLanguageKey = CookieLanguageKey;
        }

        public static string L(string key, params object[] args)
        {
            var languageKey = GlobalConstants.DefaultLanguageCode;
            if (
                    _httpContextAccessor != null && _httpContextAccessor.HttpContext != null
                    && _httpContextAccessor.HttpContext.Request.Cookies[_cookieLanguageKey] != null
                    && !string.IsNullOrEmpty(_cookieLanguageKey))
            {
                var c = _httpContextAccessor.HttpContext.Request.Cookies[_cookieLanguageKey];
                if (c != null && !string.IsNullOrEmpty(c))
                    languageKey = c.ToString();
            }

            //return Localization.LanguageConfigure.GetLocalizedValue(languageKey, key, args);
            // return LanguageConfigure.GetLocalizedValue(languageKey, key, args);
            return Empower.Utilities.LanguageConfigure.GetLocalizedValue(languageKey, key, args);
            
        }
    }
}
