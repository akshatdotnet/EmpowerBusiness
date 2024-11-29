using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // 1. Question: Explain Dependency Injection and Implement It
    // Dependency Injection using an Interface

    public class Question1
    {
        public readonly IGreetingService _greetingService;

        public Question1(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

    }
    public interface IGreetingService
    {
        void Greet(string name);
    }

    public class GreetingService : IGreetingService
    {
        public void Greet(string name) => Console.WriteLine($"Hello, {name}!");
    }

   


}
