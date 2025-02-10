using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Constants
{
    public class CurrencyMasterConsts
    {
        public const int MinCurrencyNameLength = 2;
        public const int MinCurrencyCodeLength = 3;
        public const double MinCurrencyRateLength = 0.1;
        public const int MaxCurrencyNameLength = 50;
        public const int MaxCurrencyCodeLength = 3;
        public const double MaxCurrencyRateLength = double.MaxValue;
    }
}
