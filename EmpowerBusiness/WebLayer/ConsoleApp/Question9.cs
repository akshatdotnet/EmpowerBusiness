using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //9. Question: How to Use Delegates?
    //Explanation: Delegates encapsulate methods, enabling callback mechanisms in C#.


    internal class Question9
    {
    }

    public delegate void PrintDelegate(string message);

    class Program9
    {
        static void Main()
        {
            PrintDelegate print = Console.WriteLine;
            print("Hello via Delegate!");
        }
    }

}
