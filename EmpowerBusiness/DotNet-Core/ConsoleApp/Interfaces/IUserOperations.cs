using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface Segregation Principle (ISP)
//Clients should not be forced to depend on methods they do not use.
//
//Example: Separate interfaces for specific functionalities.
//Code:
//Interfaces / IUserOperations.cs



namespace ConsoleApp.Interfaces
{
    public interface IUserOperations
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
    }

}
