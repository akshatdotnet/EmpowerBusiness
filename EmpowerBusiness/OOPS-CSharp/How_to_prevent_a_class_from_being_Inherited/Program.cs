// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public sealed class Employee
{
    public int Experience { get; set; }

    public void CalculateSalary()
    {
        int salary = Experience * 300000;

        Console.WriteLine("salary:{0} ", salary);
    }
}

//public class PermanentEmployee : Employee
//{

//}