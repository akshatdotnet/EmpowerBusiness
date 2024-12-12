using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //6. Question: Explain and Implement Interfaces
    //Explanation: Interfaces define contracts that implementing classes must adhere to.


    internal class Question6
    {
    }

    public interface IAnimal
    {
        void Speak();
    }

    public class Dog : IAnimal
    {
        public void Speak() => Console.WriteLine("Woof!");
    }

    class Program6
    {
        public static void NNNMain()
        {
            IAnimal animal = new Dog();
            animal.Speak();
        }
    }

}
