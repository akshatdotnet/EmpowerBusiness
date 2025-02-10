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
    [Table("UserDetails")]
    public class UserDetail : FullAuditedEntity
    {
        public int UserId { get; set; }
        [StringLength(UserConsts.MaxFirstNameLength)]
        public string? FirstName { get; set; }

        [StringLength(UserConsts.MaxMiddleNameLength)]
        public string? MiddleName { get; set; }

        [StringLength(UserConsts.MaxLastNameLength)]
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string? UserType { get; set; }
        public User User { get; set; } = new User();
        //public List<CustomerShippingAddress>? Shipping { get; set; }
        //public virtual List<Order>? Orders { get; set; }
    }
}
