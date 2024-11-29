using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Open / Closed Principle(OCP)
//Classes should be open for extension but closed for modification.
//Example: Create a reporting system where new reports can be added without modifying existing code.


namespace ConsoleApp.Interfaces
{
    public interface IReport
    {
        void GenerateReport();
    }

}
