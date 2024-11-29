using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //3. Question: How to Implement Async/Await?
    //Explanation: Async/await improves application responsiveness by executing tasks asynchronously.


    internal class Question3
    {
    }

    class Program3
    {
        static async Task Main()
        {
            await FetchDataAsync();
        }

        static async Task FetchDataAsync()
        {
            Console.WriteLine("Fetching data...");
            await Task.Delay(2000); // Simulates async operation
            Console.WriteLine("Data fetched!");
        }
    }

}
