using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.MyPreference
{
    public class MyPreferenceInputDTO
    {
        public int? UserId { get; set; }
        public string PreferredLanguage { get; set; } = "";
        public int CountryMasterId { get; set; } = 0;
        public int CurrencyMasterId { get; set; } = 0;
        public int MeasurementMasterId { get; set; } = 0;
    }
}
