    namespace Empower.API
{
    public class ApplicationRegExp
    {
        public const string MobileNumber = @"^[+-]?(?:\d+\d*|\d*\d+)[\r\n]*$";
        public const string EmailAddress = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
            + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
        public const string AlphaNumeric = @"^([a-zA-Z0-9]+[_\s-]*)+$";
        public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@!%*?`&!""£$%^&*()_+{}:@~<>?|=[\];'#,.\/\\-])[A-Za-z\d$@!%*?`&!""£$%^&*()_+{}:@~<>?|=[\];'#,.\/\\-]{8,}$";
    }
}
