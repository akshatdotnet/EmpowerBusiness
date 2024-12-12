using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class EvenNumberService : IEvenNumberService
    {
        public IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i <= max; i++)
            {
                if (i % 2 == 0) // Check if the number is even
                {
                    yield return i; // Return the even number
                }
            }
        }

        public void PrintEvenNumbers()
        {
            Console.WriteLine("Even numbers up to 10:");

            // Call the method from the service
            foreach (var number in GetEvenNumbers(10))
            {
                Console.WriteLine(number);
            }

        }



    }
}
