using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class UserValidator : IUserValidator
    {
        public bool Validate(User user, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                errorMessage = "User name cannot be empty.";
                return false;
            }
            if (!user.Email.Contains("@"))
            {
                errorMessage = "Invalid email format.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }

}
