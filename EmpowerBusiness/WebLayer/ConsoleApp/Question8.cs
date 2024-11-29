using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //8. Question: Implement a Custom Exception
    //Explanation: Custom exceptions provide meaningful error information specific to the domain.


    internal class Question8
    {
    }
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }

    class Program8
    {
        static void Main()
        {
            try
            {
                throw new CustomException("This is a custom exception.");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Caught: {ex.Message}");
            }
        }
    }

}
