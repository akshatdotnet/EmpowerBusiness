using Empower.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.Models.Constants;

namespace Empower.Data.Entities
{
    [Table("CountryMasters")]
    public class CountryMaster : FullAuditedEntity
    {
        [StringLength(CountryMasterConstants.MaxCountryNameLength)]
        public string Name { get; set; } = string.Empty;

        [StringLength(CountryMasterConstants.MaxISOCodeLength)]
        public string ISOCode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        [StringLength(CountryMasterConstants.MaxImageNameLength)]
        public string? ImageName { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
    }
}
