//Q.What is the difference between Overloading and Overriding?
//Method overriding is creating a method in the DERIVED class with the
//SAME NAME and SIGNATURE as a method in the base class.

//Overriding uses VIRTUAL keyword for base class method and OVERRIDE keyword for derived class method.

DerivedClass objDerived = new DerivedClass();
objDerived.Greetings();
Console.ReadLine();

//Ouptut: DerivedClass Hello

public class BaseClass
{
    public virtual void Greetings()
    {
        Console.WriteLine("BaseClass Hello!");
    }
}

public class DerivedClass : BaseClass
{
    public override void Greetings()
    {
        Console.WriteLine("DerivedClass Hello!");
    }
}