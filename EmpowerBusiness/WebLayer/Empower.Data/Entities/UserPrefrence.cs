using Empower.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Data.Entities
{
    [Table("UserPrefrences")]
    public class UserPrefrence : FullAuditedEntity
    {
        public int UserId { get; set; }
        public string PreferedLanguage { get; set; } = "";
        public int? CountryMasterId { get; set; }
        public int? CurrencyMasterId { get; set; }
        public int? MeasurementMasterId { get; set; }
    }
}
