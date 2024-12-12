using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class EmployeeManagement : IEmployeeManagement
    {
        public void EmployeeMngt()
        {
            try
            {
                // Create employees
                Employee emp1 = new Employee("E001", "Alice", 25, "HR");
                Employee emp2 = new Employee("E002", "Bob", 30, "IT");

                // Display employee details
                emp1.DisplayDetails();
                emp2.DisplayDetails();

                // Update department
                emp1.UpdateDepartment("Finance");
                Console.WriteLine("\nAfter Department Update:");
                emp1.DisplayDetails();

                // Display total employee count
                Console.WriteLine($"\nTotal Employees: {Employee.GetEmployeeCount()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //Example: Employee Management Class
        //Global Variable, Constructor, and Segregated Methods




        public class Employee
        {
            // Global variables (fields)
            private readonly string _id; // Employee ID (read-only once set)
            private string _name;
            private int _age;
            private string _department;

            // Static global variable for employee count
            private static int _employeeCount = 0;

            // Constructor
            public Employee(string id, string name, int age, string department)
            {
                if (!Helper.ValidateAge(age))
                {
                    throw new ArgumentException("Age must be between 18 and 65.");
                }

                _id = id; // ID is assigned once, not modifiable later
                _name = name;
                _age = age;
                _department = department;

                // Increment the employee count
                _employeeCount++;
            }

            // Public method to display employee details
            public void DisplayDetails()
            {
                Console.WriteLine($"Employee ID: {_id}");
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Age: {_age}");
                Console.WriteLine($"Department: {_department}");
            }

            // Public method to update employee department
            public void UpdateDepartment(string newDepartment)
            {
                if (string.IsNullOrWhiteSpace(newDepartment))
                {
                    throw new ArgumentException("Department cannot be null or empty.");
                }

                _department = newDepartment;
            }

            // Static method to get total employee count
            public static int GetEmployeeCount()
            {
                return _employeeCount;
            }

            // Private method for internal logic (e.g., formatting name)
            private string FormatName()
            {
                return _name.ToUpperInvariant();
            }

        }

        // Helper class to perform common operations
        public static class Helper
        {
            public static bool ValidateAge(int age)
            {
                return age >= 18 && age <= 65; // Valid age for an employee
            }
        }


    }
}
