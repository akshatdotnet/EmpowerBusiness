using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //10. Question: How to Use Events?
    //Explanation: Events enable communication between objects in a decoupled way.


    internal class Question10
    {
    }

    public class Publisher
    {
        public event EventHandler? OnPublish;

        public void Publish()
        {
            Console.WriteLine("Publishing...");
            OnPublish?.Invoke(this, EventArgs.Empty);
        }
    }

    class Program10
    {
        static void Main()
        {
            var publisher = new Publisher();
            publisher.OnPublish += (sender, args) => Console.WriteLine("Subscriber notified!");
            publisher.Publish();
        }
    }

}
