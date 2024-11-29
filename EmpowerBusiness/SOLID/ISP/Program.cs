//Interface Segregation Principle (ISP):
//-The Interface Segregation Principle states "that clients should not be
//  forced to implement interfaces they don't use. Instead of one fat interface,
//  many small interfaces are preferred based on groups of methods,
//  each one serving one submodule.".

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}


//public interface IVehicle
//{
//    void Drive();

//    void Fly();
//}


//public class FlyingCar : IVehicle
//{
//    public void Drive()
//    {
//        Console.Write("Drive car");
//    }

//    public void Fly()
//    {
//        Console.Write("Fly car");
//    }
//}

//public class Car : IVehicle
//{
//    public void Drive()
//    {
//        Console.Write("Drive car");
//    }

//    public void Fly()
//    {
//        throw new NotImplementedException();
//    }
//}

public interface IDrive
{
    void Drive();
}

public interface IFly
{
    void Fly();
}

public class Car : IDrive
{
    public void Drive()
    {
        Console.Write("Drive car");
    }
}

public class FlyingCar : IDrive, IFly
{
    public void Drive()
    {
        Console.Write("Drive car");
    }

    public void Fly()
    {
        Console.Write("Fly car");
    }
}
