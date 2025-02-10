using Empower.Data.Entities.Base;
using Empower.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Data.Entities
{
    [Table("MeasurementMasters")]
    public class MeasurementMaster : FullAuditedEntity
    {
        [StringLength(MeasurementMasterConsts.MaxMeasurementNameLength)]
        public string Name { get; set; } = string.Empty;
        public double Ratio { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
    }
}
