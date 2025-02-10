using Empower.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Data.Entities
{
    [Table("AccountWallet")]
    public class AccountWallet : FullAuditedEntity
    {
        public int? UserId { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal? Balance { get; set; }
        public bool? IsActive { get; set; } = true;
        public User? User { get; set; } = new();
    }
}
