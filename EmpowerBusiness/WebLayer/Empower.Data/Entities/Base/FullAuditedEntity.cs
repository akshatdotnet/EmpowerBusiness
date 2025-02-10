using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Data.Entities.Base
{
    //NOTE:
    //TODO: Restrict T to Int or Long
    //TODO: Add Unique key propery as GUID
    public class FullAuditedEntity //<T>
    {
        //public T Id { get; set; }
        public int Id { get; set; }
        public Guid UniqueId { get; set; } = Guid.NewGuid();
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
