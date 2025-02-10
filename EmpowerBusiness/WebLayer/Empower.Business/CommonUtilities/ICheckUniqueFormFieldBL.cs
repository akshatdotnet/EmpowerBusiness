using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.CommonUtilities
{
    internal interface ICheckUniqueFormFieldBL
    {
        Task<Tuple<bool, string>> CheckFormFieldExist(string moduleName, string actionType, int field1 = 0, string field2 = "");
    }
}
