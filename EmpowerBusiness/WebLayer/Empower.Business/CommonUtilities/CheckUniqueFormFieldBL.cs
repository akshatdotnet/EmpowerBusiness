using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.CommonUtilities
{
    internal class CheckUniqueFormFieldBL : ICheckUniqueFormFieldBL
    {
        public Task<Tuple<bool, string>> CheckFormFieldExist(string moduleName, string actionType, int field1 = 0, string field2 = "")
        {
            throw new NotImplementedException();
        }
    }
}
