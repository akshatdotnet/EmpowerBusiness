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
    [Table("CurrencyMasters")]
    public class CurrencyMaster : FullAuditedEntity
    {
        [StringLength(CurrencyMasterConsts.MaxCurrencyNameLength)]
        public string Name { get; set; } = string.Empty;

        [StringLength(CurrencyMasterConsts.MaxCurrencyCodeLength)]
        public string CurrencyCode { get; set; } = string.Empty;


        [Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPrimary { get; set; }
    }
}
