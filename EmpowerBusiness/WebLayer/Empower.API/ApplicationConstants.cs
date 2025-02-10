using Empower.Models.Enums;

namespace Empower.API
{
    public class ApplicationConstants
    {
        public const string OwnerName = "Vaishnav Engineering";

        public const string AppName = "ECom";

        public static string PoweredBy = $@"&copy; {DateTime.Now.Year} - Powered By <a class=""text-white"" href=""https://www.vaishnavtechnologies.com/"">Vaishnav Engineering</a>";


        public const string MobileOtpMedia = OtpMediaEnum.MobileOtpMedia;
    }
}
