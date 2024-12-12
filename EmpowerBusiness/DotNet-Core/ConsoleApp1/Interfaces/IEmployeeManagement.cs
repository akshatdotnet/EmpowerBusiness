using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IEmployeeManagement
    {
        void EmployeeMngt();
    }

    /*
     * Key Best Practices Followed
      1. Global Variables (Fields)
      Private fields:
      Encapsulated _id, _name, _age, and _department fields are private to prevent direct access.
      Static fields:
      _employeeCount keeps track of the total number of employees and is accessible through a static method.
      2. Constructor
      Accepts and initializes required properties (id, name, age, and department).
      Uses a helper class to validate employee age before assignment.
      3. Public Methods
      DisplayDetails: Displays employee information.
      UpdateDepartment: Allows updating the department with validation.
      GetEmployeeCount: A static method for retrieving the total employee count.
      4. Private Methods
      FormatName: Demonstrates internal logic, such as formatting a string (used internally, can be extended as needed).
      5. Helper Class
      Helper is a static class with reusable logic (e.g., age validation).
      6. Error Handling
      Throws exceptions with meaningful messages for invalid data.
      Includes a try-catch block in Main to handle runtime exceptions gracefully.
      7. Static Context
      Maintains shared state (_employeeCount) across all instances of the Employee class.
      8. Immutability
      The _id field is read-only to ensure the employee ID is immutable once assigned. 
     */

}
