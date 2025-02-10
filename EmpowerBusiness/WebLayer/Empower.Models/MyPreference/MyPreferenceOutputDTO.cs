using Empower.Models.Country;
using Empower.Models.Currency;
using Empower.Models.Measurement;
using Empower.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.MyPreference
{
    public class MyPreferenceOutputDTO
    {
        public int? UserId { get; set; }
        public string? PreferredLanguage { get; set; } = "";
        public int? CountryMasterId { get; set; }
        public int? CurrencyMasterId { get; set; }
        public int? MeasurementMasterId { get; set; }
        public List<CountryMasterDTO> CountryList { get; set; } = new();
        public List<CurrencyMasterDTO> CurrencyList { get; set; } = new();
        public List<MeasurementMasterDTO> MeasurementList { get; set; } = new();
        public List<Language>? LanguageList { get; set; }
    }
}
