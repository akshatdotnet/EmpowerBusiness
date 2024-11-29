using System.Text.Json;


namespace ConsoleApp
{
    //5. Question: How to Serialize/Deserialize JSON?
    //Explanation: Use System.Text.Json for efficient JSON serialization/deserialization.


    internal class Question5
    {
    }


    class Program5
    {
        static void Main()
        {
            var person = new { Name = "Alice", Age = 25 };
            string jsonString = JsonSerializer.Serialize(person);
            Console.WriteLine($"Serialized: {jsonString}");

            var deserialized = JsonSerializer.Deserialize<dynamic>(jsonString);
            Console.WriteLine($"Deserialized: {deserialized["Name"]}");
        }
    }

}
