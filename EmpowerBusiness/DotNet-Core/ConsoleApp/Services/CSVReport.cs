using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class CSVReport : IReport
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating CSV Report...");
        }
    }

}
