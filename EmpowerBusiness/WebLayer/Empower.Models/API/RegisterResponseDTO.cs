using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Empower.Models.API
{
    public class RegisterResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public int Id { get; set; }
        public Guid UniqueId { get; set; } = new();
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        [JsonIgnore]
        public string MobileNo { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}
