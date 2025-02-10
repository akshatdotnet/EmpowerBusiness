using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.MyPreference
{
    public class MyPreferenceInsertOutputDTO
    {
        public bool IsUserPreferenceInserted { get; set; }
        public bool NoRecordToSave { get; set; }
        public int CurrencyMasterId { get; set; }
        public int CountryMasterId { get; set; }
        public string PreferredLanguage { get; set; } = String.Empty;
        public int MeasurementMasterId { get; set; }
        public string MeasurementMasterName { get; set; } = String.Empty;
        public bool IsUserPreferenceUpdated { get; set; }
    }
}
