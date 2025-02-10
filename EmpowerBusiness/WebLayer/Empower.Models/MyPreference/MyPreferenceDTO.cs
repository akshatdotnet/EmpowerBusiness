using Empower.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.MyPreference
{
    public class MyPreferenceDTO
    {
        public string PreferredLanguage { get; set; } = GlobalConstants.DefaultLanguageCode;
        public int CountryMasterId { get; set; } = 0;
        public int CurrencyMasterId { get; set; } = 0;
        public int MeasurementMasterId { get; set; } = 0;
        public string MeasurementName { get; set; } = string.Empty;
    }

    public class MyPreferenceCountryDTO
    {
        public int CountryMasterId { get; set; } = 0;
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ISOCode { get; set; } = string.Empty;
    }

}
