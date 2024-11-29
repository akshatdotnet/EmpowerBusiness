using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //Q. What is the difference between “Readonly” and “Constant” variables (atleast 3)?
    //namespace What_is_the_difference_between_Readonly_and_Constant_variables
    public class Example
    {
        public const int myConst = 10;
        //public const int myConst1;

        public readonly int myReadonly1 = 100;
        public readonly int myReadonly2;

        //myconst = 20;
        public Example(int b)
        {
            myReadonly2 = b * 100;

            // myConst = 20;

            Console.WriteLine(myReadonly1);
            Console.WriteLine(myReadonly2);
        }
    }
}
