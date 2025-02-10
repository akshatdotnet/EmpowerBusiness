using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Country
{
    public class CountryMasterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ISOCode { get; set; } = string.Empty;
        public string CountryGuid { get; set; } = string.Empty;

    }
}
