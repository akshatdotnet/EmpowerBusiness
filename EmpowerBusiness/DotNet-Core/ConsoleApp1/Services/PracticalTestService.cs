using ConsoleApp1.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1.Services
{
    public class PracticalTestService : IPracticalTest
    {

        #region 1.Reverse String Example
        public void ReverseString()
        {
            string reversestring = ReverseString("hello");
            Console.WriteLine(reversestring);
            Console.ReadLine();

        }

        public static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        #endregion

        #region 2.Check for Palindrome Example

        public void Palindrome()
        {
            bool IsPalidrome = IsPalindrome("madam");
            Console.WriteLine(IsPalidrome);
            Console.ReadLine();
            // Input: "madam"
            // Output: true
        }

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

        #endregion

        #region 3.Find Duplicates in an Array
        public void FindDuplicates()
        {
            List<int> duplicateNumbers = FindDuplicates([1, 2, 3, 1, 4, 2]);
            // Console.WriteLine(Numbers);
            // Print duplicates
            //Console.WriteLine("Duplicate numbers: " + string.Join(", ", duplicateNumbers));
            Console.WriteLine("[" + string.Join(", ", duplicateNumbers) + "]");


            // Input: [1, 2, 3, 1, 4, 2]
            // Output: [1, 2]
        }
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

        #endregion

        #region 4. Print Fibonacci Series

        public void PrintFibonacci()
        {
            PrintFibonacci(5);
            // Input: 5
            // Output: 0 1 1 2 3
        }
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

        #endregion

        #region 5. Implement Singleton Pattern
        public void SingletoneExample()
        {

        }
        public sealed class Singleton
        {
            private static readonly Lazy<Singleton> _instance = new(() => new Singleton());

            private Singleton() { }

            public static Singleton Instance => _instance.Value;
        }

        #endregion

        #region 6. LINQ Query to Filter and Sort
        public void FilterAndSortExample()
        {
            List<int> FilterAndSortNumbers = FilterAndSort([3, 5, 2, 8, 6]);

            // FilterAndSort
            Console.WriteLine("[" + string.Join(", ", FilterAndSortNumbers) + "]");

            // Input: [3, 5, 2, 8, 6]
            // Output: [8, 6, 2]
        }
        public static List<int> FilterAndSort(int[] numbers)
        {
            return numbers.Where(n => n % 2 == 0).OrderByDescending(n => n).ToList();
        }


        #endregion

        #region 7. Find the First Non-Repeating Character
        public void FirstNonRepeatingCharExample()
        {
            var charactpr = FirstNonRepeatingChar("swiss");
            Console.WriteLine(charactpr);

            // Input: "swiss"
            // Output: 'w'
        }

        public static char? FirstNonRepeatingChar(string input)
        {
            var count = new Dictionary<char, int>();

            foreach (var c in input)
                count[c] = count.GetValueOrDefault(c, 0) + 1;

            return input.FirstOrDefault(c => count[c] == 1);
        }

        #endregion

        #region 8. Multithreading Example
        public void PrintNumbersExample()
        {
            PrintNumbers();
        }

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

        #endregion

        #region 9. Dependency Injection Example

        public void DependencyInjectionExample()
        {
            ILogger logger = new ConsoleLogger();
            var app = new Application(logger);
            app.Run();

            // Usage
            //ILogger logger = new ConsoleLogger();
            //var app = new Application(logger);
            //app.Run();

        }

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


        #endregion

        #region 10. Calculate Factorial Using Recursion
        public void FactorialExample()
        {
            Factorial(5);
            // Input: 5
            // Output: 120
        }

        public static int Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return n * Factorial(n - 1);
        }

        #endregion

        #region 1. Sort a Custom Object Using LINQ
        public void sortLinqExample()
        {
            sortLinq();

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
        }
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
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Salary { get; set; }
        }

        #endregion

        #region 2. Custom Exception Handling
        public void CustExcepExample()
        {
            CustExcep();
        }
        public static void CustExcep()
        {
            try
            {
                Console.Write("Enter your age: ");
                int age = int.Parse(Console.ReadLine());
                ValidateAge(age);
            }
            catch (AgeValidationException ex)
            {
                Console.WriteLine($"Custom Exception Caught: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception Caught: {ex.Message}");
            }
        }

        // Step 1: Define a custom exception class
        public class AgeValidationException : Exception
        {
            public AgeValidationException(string message) : base(message) { }
        }

        //Enter your age: 16
        //Custom Exception Caught: Age must be 18 or older.
        static void ValidateAge(int age)
        {
            if (age < 18)
            {
                throw new AgeValidationException("Age must be 18 or older.");
            }
            Console.WriteLine("Age is valid.");
        }

        #endregion

        #region Factory Pattern

        public void factorygenerateExample()
        {
            factorygenerate();
        }

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
        #endregion

        #region Strategy Pattern
        public void strategiescalculatingExample()
        {
            strategiescalculating();
            //Choose Discount Type: 1-No Discount, 2-Seasonal, 3-Clearance
            //2
            //Enter the original price: 100
            //Total Price after Discount: 90

        }
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

        #endregion


        #region 1. LINQ: Grouping and Aggregation
        public void GetCalculateSalesExample()
        {
            GetCalculateSales();
        }

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


        #endregion


        #region 2. Multithreading: Producer-Consumer Problem
        public void MultithreadingExample()
        {
            BlockingCollection();

            //Producing: 1
            //Producing: 2
            //Consuming: 1
            //Producing: 3
            //Consuming: 2
        }

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

        #endregion



        #region 3. OOP: Implement Polymorphism with Virtual Methods
        public void EmpBasedRolesExample()
        {
            empbonesebasedroles();

            //Alice's Bonus: 5000
            //Bob's Bonus: 12000
        }
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

        #endregion

        #region 4. Event Handling with Delegates

        public void EvenExamHandDelExample()
        {
            notificationtriggers();
        }
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

        #endregion

        #region 5. Design Patterns: Repository Pattern with Dependency Injection
        public void repositoryDiExample()
        {
            repositoryDi();

            //Users:
            //Alice
            //Bob
            //Charlie

        }
        public static void repositoryDi()
        {
            IUserRepository userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            Console.WriteLine("Users:");
            userService.DisplayUsers();
        }
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

        #endregion

        #region 6. Async/Await with Task
        public void FechDataAsyncExample()
        {
            FechDataAsync();
            //Fetching data...
            //Data fetched from API
        }
        public async static void FechDataAsync()
        {
            var apiService = new ApiService();
            Console.WriteLine("Fetching data...");
            string data = await apiService.GetDataAsync();
            Console.WriteLine(data);
        }
        public class ApiService
        {
            public async Task<string> GetDataAsync()
            {
                await Task.Delay(2000); // Simulate network delay
                return "Data fetched from API";
            }
        }

        #endregion


        #region 7. Generic Repository with LINQ

        public void GenericRepoExample()
        {
            GenRepoCrud();
        }


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

        #endregion


        #region ListingNode
        public void ListingNodeExample()
        {
            ListingNode();
        }

        //Input [1, 2, 3, 4]
        public static void ListingNode()
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                ListNode head = StringToListNode(line);
                PrettyPrintLinkedList(head);
            }
        }
        //Output 1->2->3->4


        public class ListNode //This is a simple linked list node definition.
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        //These Helper methods remove leading and trailing spaces from a string.
        public static void TrimLeftTrailingSpaces(ref string input)
        {
            input = input.TrimStart();
        }

        public static void TrimRightTrailingSpaces(ref string input)
        {
            input = input.TrimEnd();
        }

        //This method converts a string representation of a list (e.g., "[1, 2, 3]") into a List<int>.
        public static List<int> StringToIntegerList(string input)
        {
            List<int> output = new List<int>();
            TrimLeftTrailingSpaces(ref input);
            TrimRightTrailingSpaces(ref input);
            input = input.Substring(1, input.Length - 2);
            string[] items = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                output.Add(int.Parse(item));
            }
            return output;
        }

        //This method converts the List<int> into a linked list of type ListNode.
        public static ListNode StringToListNode(string input)
        {
            // Generate list from the input
            List<int> list = StringToIntegerList(input);

            // Now convert that list into linked list
            ListNode dummyRoot = new ListNode(0);
            ListNode ptr = dummyRoot;
            foreach (int item in list)
            {
                ptr.next = new ListNode(item);
                ptr = ptr.next;
            }
            ptr = dummyRoot.next;
            return ptr;
        }

        //This method prints a linked list in a human-readable format.
        public static void PrettyPrintLinkedList(ListNode node)
        {
            while (node != null && node.next != null)
            {
                Console.Write(node.val + "->");
                node = node.next;
            }

            if (node != null)
            {
                Console.WriteLine(node.val);
            }
            else
            {
                Console.WriteLine("Empty LinkedList");
            }
        }

        #endregion


        #region inputString
        
        public void inputStringExample()
        {
            string inputString = "DDAABCCA";
            string output = CountCharacters(inputString);
            Console.WriteLine(output);
            //Output : D2A2B1C2A1
        }
        public static string CountCharacters(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            StringBuilder result = new StringBuilder(); // To store the final result
            int count = 1; // Counter for character occurrences

            // Loop through the string to count consecutive characters
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    count++; // Increment the count if the character matches the previous one
                }
                else
                {
                    result.Append(input[i - 1]); // Append the character
                    result.Append(count); // Append its count
                    count = 1; // Reset count
                }
            }

            // Append the last character and its count
            result.Append(input[input.Length - 1]);
            result.Append(count);

            return result.ToString();
        }

        #endregion


        #region PartialClassExample
        public void PartialClassExample()
        {
            PartialClass();
        }

        public void PartialClass()
        {
            Employee2 emp = new Employee2
            {
                FirstName = "John",
                LastName = "Doe",
                Department = "IT",
                Salary = 60000
            };

            Console.WriteLine($"Full Name: {emp.GetFullName()}");
            emp.DisplayProfessionalInfo();
        }

        public class Employee2
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Department { get; set; }
            public double Salary { get; set; }

            public string GetFullName()
            {
                return $"{FirstName} {LastName}";
            }

            public void DisplayProfessionalInfo()
            {
                Console.WriteLine($"Department: {Department}, Salary: {Salary}");
            }
        }
        #endregion
    }
}
