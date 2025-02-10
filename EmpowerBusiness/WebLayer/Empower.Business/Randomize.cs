using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business
{
    public static class Randomize
    {
        public static string GetRandomString(int length = 10)
        {
            Random random = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            string randomString = new(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return randomString;
        }
        public static int GenerateRandomOTP(int iOTPLength = 6)
        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string sOTP = string.Empty;
            Random rand = new();
            for (int i = 0; i < iOTPLength; i++)
            {
                sOTP += saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
            }
            return Convert.ToInt32(sOTP);
        }
        /// <summary>
        /// To generate password for admin users
        /// </summary>
        /// <param name="passwordSize"></param>
        /// <returns></returns>
        public static string GetRandomPassword()
        {
            Random random = new();
            const string charsLowerCase = @"abcdefghijklmnopqursuvwxyz";
            const string charsUpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string charsNumber = "0123456789";
            const string charsSpecial = "$@!%*?`&!\"£$%^&*()_+{}:@~<>?|=[\\];'#,.\\/\\\\-";

            string randomString = new(Enumerable.Repeat(charsUpperCase, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            randomString += new string(Enumerable.Repeat(charsNumber, 2)
            .Select(s => s[random.Next(s.Length)]).ToArray());
            randomString += new string(Enumerable.Repeat(charsSpecial, 2)
             .Select(s => s[random.Next(s.Length)]).ToArray());
            randomString += new string(Enumerable.Repeat(charsLowerCase, 3)
             .Select(s => s[random.Next(s.Length)]).ToArray());


            return randomString;
        }
    }
}
