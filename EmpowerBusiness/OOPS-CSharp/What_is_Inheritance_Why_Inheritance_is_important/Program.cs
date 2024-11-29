

PermanentEmployee pEmployee = new PermanentEmployee();
pEmployee.Experience = 5;
pEmployee.CalculateSalary();

Console.ReadLine();



public class Employee
{
    public int Experience { get; set; }

    public void CalculateSalary()
    {
        int salary = Experience * 300000;

        Console.WriteLine("salary:{0} ", salary);
    }
}

public class PermanentEmployee : Employee
{
    //No method or Property here
}
