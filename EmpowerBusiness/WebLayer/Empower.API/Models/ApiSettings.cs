namespace Empower.API.Models
{
    public class ApiSettings
    {
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int TokenLife { get; set; }
        public bool ShowDevError { get; set; }
    }
}
