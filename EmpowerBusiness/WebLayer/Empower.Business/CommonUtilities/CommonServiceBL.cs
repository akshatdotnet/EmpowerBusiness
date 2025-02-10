using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.CommonUtilities
{
    internal class CommonServiceBL : ICommonServiceBL
    {
        public Task<Tuple<StringBuilder, List<string>>> CheckDbColumnsExistOrNot(DataColumnCollection dtColumn)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<StringBuilder, List<string>, ExcelWorksheet, DataTable>> CheckFileColumnsExistOrNot(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetEntityDataByName(string entity, string value, string field1 = "", int filed2 = 0, int Field3 = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ExcelWorksheet> ReadExcelFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
