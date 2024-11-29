using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //2. Question: How to Handle Exceptions Gracefully?

    internal class Question2
    {
        
    }


    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter a number: ");
                int number = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            finally
            {
                Console.WriteLine("Execution completed.");
            }
        }
    }

}
