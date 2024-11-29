using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //4. Question: Demonstrate LINQ Queries
    //Explanation: LINQ provides a declarative way to query collections in C#.


    internal class Question4
    {
    }

    class Program4
    {
        static void Main()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

            Console.WriteLine("Even Numbers:");
            evenNumbers.ForEach(Console.WriteLine);
        }
    }

}
