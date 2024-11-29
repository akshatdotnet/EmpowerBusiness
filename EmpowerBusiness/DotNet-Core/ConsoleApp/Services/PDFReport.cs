using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Liskov Substitution Principle (LSP)
//Derived classes must be substitutable for their base class.
//
//Example: Ensure all reports implement the IReport interface and behave consistently.
//Code:
//The CSVReport and PDFReport classes above ensure LSP compliance because they can replace IReport.



namespace ConsoleApp.Services
{
    public class PDFReport : IReport
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating PDF Report...");
        }
    }
}
