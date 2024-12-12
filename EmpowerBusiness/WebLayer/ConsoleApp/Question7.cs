using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //7. Question: How to Use Generics?
    //Explanation: Generics provide type safety and reduce code duplication.


    internal class Question7
    {
    }

    class Program7
    {
        public static void NNNMain()
        {
            var list = new List<int> { 1, 2, 3 };
            PrintItems(list);
        }

        static void PrintItems<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

}
