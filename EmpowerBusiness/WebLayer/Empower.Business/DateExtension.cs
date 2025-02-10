using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business
{
    internal static class DateExtension
    {
        internal static string ToGlobalDateFormat(this DateTime dateTime)
        {
            string returnDate;
            try
            {
                returnDate = dateTime.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw;
            }
            return returnDate;
        }

        internal static string ToGlobalDateFormatWithTime(this DateTime dateTime)
        {
            string returnDate;
            try
            {
                returnDate = dateTime.ToString("dd MMMM yyyy hh:mm tt", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw;
            }
            return returnDate;
        }

        internal static string ToGlobalUserDateFormat(this DateTime dateTime)
        {
            string returnDate;
            try
            {
                returnDate = dateTime.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw;
            }
            return returnDate;
        }
        internal static string ToGlobalUserDateFormatWithTime(this DateTime dateTime)
        {
            string returnDate;
            try
            {
                returnDate = dateTime.ToString("dd/MM/yyyy h:mm tt", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw;
            }
            return returnDate;
        }
    }
}
