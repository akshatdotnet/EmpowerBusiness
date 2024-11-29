using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static ConsoleApp1.PracticalTest;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class PracticalTest
    {
        //1. Reverse a String
        //Problem: Write a method to reverse a string without using built-in reverse functions.
        public static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        // Input: "hello"
        // Output: "olleh"

        //2. Check for Palindrome
        //Problem: Write a method to check if a string is a palindrome.
        public static bool IsPalindrome(string input)
        {
            int start = 0, end = input.Length - 1;
            while (start < end)
            {
                if (input[start++] != input[end--])
                    return false;
            }
            return true;
        }
        // Input: "madam"
        // Output: true

        //3.Find Duplicates in an Array
        //Problem: Write a method to find duplicate elements in an array.
        public static List<int> FindDuplicates(int[] numbers)
        {
            var duplicates = new List<int>();
            var set = new HashSet<int>();

            foreach (var num in numbers)
            {
                if (!set.Add(num))
                    duplicates.Add(num);
            }
            return duplicates;
        }

        // Input: [1, 2, 3, 1, 4, 2]
        // Output: [1, 2]

        //4. Print Fibonacci Series
        //Problem: Generate the first N Fibonacci numbers.
        public static void PrintFibonacci(int n)
        {
            int a = 0, b = 1;
            Console.Write($"{a} {b} ");

            for (int i = 2; i < n; i++)
            {
                int c = a + b;
                Console.Write($"{c} ");
                a = b;
                b = c;
            }
        }

        // Input: 5
        // Output: 0 1 1 2 3

        //5. Implement Singleton Pattern
        //Problem: Create a thread-safe Singleton class.
        public sealed class Singleton
        {
            private static readonly Lazy<Singleton> _instance = new(() => new Singleton());

            private Singleton() { }

            public static Singleton Instance => _instance.Value;
        }

        //6. LINQ Query to Filter and Sort
        //Problem: Use LINQ to filter even numbers and sort them in descending order.
        public static List<int> FilterAndSort(int[] numbers)
        {
            return numbers.Where(n => n % 2 == 0).OrderByDescending(n => n).ToList();
        }

        // Input: [3, 5, 2, 8, 6]
        // Output: [8, 6, 2]

        //7. Find the First Non-Repeating Character
        //Problem: Find the first non-repeating character in a string.
        public static char? FirstNonRepeatingChar(string input)
        {
            var count = new Dictionary<char, int>();

            foreach (var c in input)
                count[c] = count.GetValueOrDefault(c, 0) + 1;

            return input.FirstOrDefault(c => count[c] == 1);
        }

        // Input: "swiss"
        // Output: 'w'

        //8. Multithreading Example
        //Problem: Use multithreading to print numbers from 1 to 10 in two threads.
        public static void PrintNumbers()
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 1; i <= 5; i++)
                    Console.WriteLine($"Thread 1: {i}");
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 6; i <= 10; i++)
                    Console.WriteLine($"Thread 2: {i}");
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }


        //9. Dependency Injection Example
        //Problem: Demonstrate Dependency Injection using interfaces.
        public interface ILogger
        {
            void Log(string message);
        }

        public class ConsoleLogger : ILogger
        {
            public void Log(string message) => Console.WriteLine(message);
        }

        public class Application
        {
            private readonly ILogger _logger;

            public Application(ILogger logger) => _logger = logger;

            public void Run() => _logger.Log("Application is running");
        }

        // Usage
        //ILogger logger = new ConsoleLogger();
        //var app = new Application(logger);
        //app.Run();

        //10. Calculate Factorial Using Recursion
        //Problem: Write a method to calculate the factorial of a number using recursion.
        public static int Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return n * Factorial(n - 1);
        }

        // Input: 5
        // Output: 120

        //1. Sort a Custom Object Using LINQ
        //Problem: Sort a list of employees by their salary in ascending and descending order.

        public static void sortLinq()
        {
            var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Salary = 60000 },
            new Employee { Id = 2, Name = "Bob", Salary = 50000 },
            new Employee { Id = 3, Name = "Charlie", Salary = 70000 }
        };

            // Sort by Salary (Ascending)
            var sortedAsc = employees.OrderBy(e => e.Salary).ToList();
            Console.WriteLine("Employees sorted by Salary (Ascending):");
            sortedAsc.ForEach(e => Console.WriteLine($"{e.Name}: {e.Salary}"));

            // Sort by Salary (Descending)
            var sortedDesc = employees.OrderByDescending(e => e.Salary).ToList();
            Console.WriteLine("\nEmployees sorted by Salary (Descending):");
            sortedDesc.ForEach(e => Console.WriteLine($"{e.Name}: {e.Salary}"));

        }
        //Output:

        //Employees sorted by Salary(Ascending):
        //Bob: 50000
        //Alice: 60000
        //Charlie: 70000
        //
        //Employees sorted by Salary(Descending):
        //Charlie: 70000
        //Alice: 60000
        //Bob: 50000

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Salary { get; set; }
        }


        //2. Custom Exception Handling
        //Problem: Create a custom exception class and demonstrate its usage.
        public static void CustExcep()
        {
            try
            {
                Console.Write("Enter your age: ");
                int age = int.Parse(Console.ReadLine());
                ValidateAge(age);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine($"Custom Exception Caught: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception Caught: {ex.Message}");
            }
        }

        //Enter your age: 16
        //Custom Exception Caught: Age must be 18 or older.

        static void ValidateAge(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException("Age must be 18 or older.");
            }
            Console.WriteLine("Age is valid.");
        }

        //Factory Pattern
        //Problem: Create a factory to generate different types of shapes.
        public static void factorygenerate()
        {
            Console.Write("Enter the shape to draw (circle/rectangle): ");
            string shapeType = Console.ReadLine();
            IShape shape = ShapeFactory.GetShape(shapeType);
            shape.Draw();
        }
        public interface IShape
        {
            void Draw();
        }

        public class Circle : IShape
        {
            public void Draw() => Console.WriteLine("Drawing a Circle");
        }

        public class Rectangle : IShape
        {
            public void Draw() => Console.WriteLine("Drawing a Rectangle");
        }

        public class ShapeFactory
        {
            public static IShape GetShape(string shapeType)
            {
                return shapeType.ToLower() switch
                {
                    "circle" => new Circle(),
                    "rectangle" => new Rectangle(),
                    _ => throw new ArgumentException("Invalid shape type")
                };
            }
        }
        //Enter the shape to draw(circle/rectangle) : circle
        //Drawing a Circle

        //Strategy Pattern
        //Problem: Implement different strategies for calculating discounts.

        public static void strategiescalculating()
        {
            Console.WriteLine("Choose Discount Type: 1-No Discount, 2-Seasonal, 3-Clearance");
            int choice = int.Parse(Console.ReadLine());

            IDiscountStrategy discountStrategy = choice switch
            {
                1 => new NoDiscount(),
                2 => new SeasonalDiscount(),
                3 => new ClearanceDiscount(),
                _ => throw new ArgumentException("Invalid choice")
            };

            var cart = new ShoppingCart(discountStrategy);

            Console.Write("Enter the original price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            decimal total = cart.CalculateTotal(price);
            Console.WriteLine($"Total Price after Discount: {total}");
        }

        //Choose Discount Type: 1-No Discount, 2-Seasonal, 3-Clearance
        //2
        //Enter the original price: 100
        //Total Price after Discount: 90


        public interface IDiscountStrategy
        {
            decimal ApplyDiscount(decimal price);
        }

        public class NoDiscount : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal price) => price;
        }

        public class SeasonalDiscount : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal price) => price * 0.9m; // 10% off
        }

        public class ClearanceDiscount : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal price) => price * 0.7m; // 30% off
        }

        public class ShoppingCart
        {
            private readonly IDiscountStrategy _discountStrategy;

            public ShoppingCart(IDiscountStrategy discountStrategy)
            {
                _discountStrategy = discountStrategy;
            }

            public decimal CalculateTotal(decimal price)
            {
                return _discountStrategy.ApplyDiscount(price);
            }
        }



        //1. LINQ: Grouping and Aggregation
        //Problem: Given a list of sales data, calculate the total sales for each product category.

        public static void GetCalculateSales()
        {
            var sales = new List<Sale>
            {
                new Sale { ProductCategory = "Electronics", Amount = 500 },
                new Sale { ProductCategory = "Clothing", Amount = 200 },
                new Sale { ProductCategory = "Electronics", Amount = 300 },
                new Sale { ProductCategory = "Clothing", Amount = 400 },
                new Sale { ProductCategory = "Furniture", Amount = 700 }
            };

            var groupedSales = sales
            .GroupBy(s => s.ProductCategory)
            .Select(group => new
            {
                Category = group.Key,
                TotalSales = group.Sum(s => s.Amount)
            });

            Console.WriteLine("Sales by Category:");
            foreach (var sale in groupedSales)
            {
                Console.WriteLine($"{sale.Category}: {sale.TotalSales}");
            }

        }

        //Sales by Category:
        //Electronics: 800
        //Clothing: 600
        //Furniture: 700

        public class Sale
        {
            public string ProductCategory { get; set; }
            public decimal Amount { get; set; }
        }

        //2. Multithreading: Producer-Consumer Problem
        //Problem: Implement a thread-safe producer-consumer queue using BlockingCollection.

        public static void BlockingCollection()
        {
            var queue = new BlockingCollection<int>(boundedCapacity: 5);

            // Producer
            Task producer = Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"Producing: {i}");
                    queue.Add(i);
                    Thread.Sleep(500);
                }
                queue.CompleteAdding();
            });

            // Consumer
            Task consumer = Task.Run(() =>
            {
                foreach (var item in queue.GetConsumingEnumerable())
                {
                    Console.WriteLine($"Consuming: {item}");
                    Thread.Sleep(1000);
                }
            });

            Task.WaitAll(producer, consumer);
        }

        //Producing: 1
        //Producing: 2
        //Consuming: 1
        //Producing: 3
        //Consuming: 2

        //3. OOP: Implement Polymorphism with Virtual Methods
        //Problem: Create a system where employees can have different types of bonuses based on their roles.


        public static void empbonesebasedroles()
        {
            var employees = new List<Employee1>
            {
                new Manager { Name = "Alice", BaseSalary = 50000 },
                new Developer { Name = "Bob", BaseSalary = 60000 }
            };

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name}'s Bonus: {employee.CalculateBonus()}");
            }

        }

        //Alice's Bonus: 5000
        //Bob's Bonus: 12000


        public abstract class Employee1
        {
            public string Name { get; set; }
            public decimal BaseSalary { get; set; }

            public abstract decimal CalculateBonus();
        }

        public class Manager : Employee1
        {
            public override decimal CalculateBonus() => BaseSalary * 0.1m;
        }

        public class Developer : Employee1
        {
            public override decimal CalculateBonus() => BaseSalary * 0.2m;
        }


        //4. Event Handling with Delegates
        //Problem: Implement a notification system that triggers an event when a file is uploaded.
        public static void notificationtriggers()
        {
            var uploader = new FileUploader();
            var notificationService = new NotificationService();

            uploader.FileUploaded += notificationService.OnFileUploaded;

            uploader.UploadFile("example.txt");
        }

        //Uploading example.txt...
        //Notification: example.txt has been uploaded.

        public class FileUploader
        {
            public delegate void FileUploadedEventHandler(object sender, string fileName);
            public event FileUploadedEventHandler FileUploaded;

            public void UploadFile(string fileName)
            {
                Console.WriteLine($"Uploading {fileName}...");
                // Simulate file upload
                System.Threading.Thread.Sleep(1000);
                OnFileUploaded(fileName);
            }

            protected virtual void OnFileUploaded(string fileName)
            {
                FileUploaded?.Invoke(this, fileName);
            }
        }

        public class NotificationService
        {
            public void OnFileUploaded(object sender, string fileName)
            {
                Console.WriteLine($"Notification: {fileName} has been uploaded.");
            }
        }


        //5. Design Patterns: Repository Pattern with Dependency Injection
        //Problem: Create a repository layer for accessing user data with dependency injection.

        public static void repositoryDi()
        {
            IUserRepository userRepository = new UserRepository();
            var userService = new UserService(userRepository);

            Console.WriteLine("Users:");
            userService.DisplayUsers();

        }

        //Users:
        //Alice
        //Bob
        //Charlie


        public interface IUserRepository
        {
            IEnumerable<string> GetAllUsers();
        }

        public class UserRepository : IUserRepository
        {
            public IEnumerable<string> GetAllUsers()
            {
                return new List<string> { "Alice", "Bob", "Charlie" };
            }
        }

        public class UserService
        {
            private readonly IUserRepository _userRepository;

            public UserService(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public void DisplayUsers()
            {
                foreach (var user in _userRepository.GetAllUsers())
                {
                    Console.WriteLine(user);
                }
            }
        }


        //6. Async/Await with Task
        //Problem: Fetch data asynchronously from a simulated API.

        public async static void FechDataAsync()
        {
            var apiService = new ApiService();
            Console.WriteLine("Fetching data...");
            string data = await apiService.GetDataAsync();
            Console.WriteLine(data);
        }
        //Fetching data...
        //Data fetched from API

        public class ApiService
        {
            public async Task<string> GetDataAsync()
            {
                await Task.Delay(2000); // Simulate network delay
                return "Data fetched from API";
            }
        }


        //7. Generic Repository with LINQ
        //Problem: Create a generic repository to perform CRUD operations.

        public static void GenRepoCrud()
        {
            var repository = new Repository<Product>();
            repository.Add(new Product { Id = 1, Name = "Laptop" });
            repository.Add(new Product { Id = 2, Name = "Mouse" });

            Console.WriteLine("Products:");
            foreach (var product in repository.GetAll())
            {
                Console.WriteLine($"{product.Id} - {product.Name}");
            }
        }

        //Products:
        //1 - Laptop
        //2 - Mouse


        public interface IRepository<T> where T : class
        {
            void Add(T entity);
            IEnumerable<T> GetAll();
            T GetById(int id);
            void Delete(T entity);
        }

        public class Repository<T> : IRepository<T> where T : class
        {
            private readonly List<T> _context = new();
            public void Add(T entity) => _context.Add(entity);
            public IEnumerable<T> GetAll() => _context;
            public T GetById(int id) => _context.FirstOrDefault();
            public void Delete(T entity) => _context.Remove(entity);
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }






    }
}
