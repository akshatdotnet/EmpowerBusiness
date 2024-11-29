﻿//Liskov substitution Principle (LSP):
//-The Liskov Substitution Principle (LSP) states that "you should be able to use any
//  derived class instead of a parent class and have it behave in the same manner without
//  modification". It ensures that a derived class does not affect the behavior of the
//  parent class, in other words, that a derived class must be substitutable for its base class.

//Base/ Parent/ Superclass
public class Employee
{
    public virtual int CalculateSalary()
    {
        return 100000;
    }
    public virtual int CalculateBonus()
    {
        return 10000;
    }
}

//Derived/ Child/ Subclass
public class PermanentEmployee : Employee
{
    public override int CalculateSalary()
    {
        return 200000;
    }
}

public class ContractualEmployee : Employee
{
    public override int CalculateSalary()
    {
        return 150000;
    }
    public override int CalculateBonus()
    {
        throw new NotImplementedException();
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee();

        PermanentEmployee pEmployee = new PermanentEmployee();

        ContractualEmployee cEmployee = new ContractualEmployee();

        Console.WriteLine(employee.CalculateSalary());
        //100000
        Console.WriteLine(employee.CalculateBonus());
        //10000            

        Console.WriteLine(pEmployee.CalculateSalary());
        //200000
        Console.WriteLine(pEmployee.CalculateBonus());
        //10000            

        Console.WriteLine(cEmployee.CalculateSalary());
        //150000
        Console.WriteLine(cEmployee.CalculateBonus());
        //Exception: The method or operation is not implemented             
    }
}