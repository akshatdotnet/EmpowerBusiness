//Dependency Inversion Principle (DIP):
//-The Dependency Inversion Principle (DIP) states that high-level modules/classes
//  should not depend on low-level modules/classes. Both should depend upon abstractions.
//                 Secondly, abstractions should not depend upon details.
//  Details should depend upon abstractions.


static void Main(string[] args)
{
    FileLogger logger = new FileLogger();
    DataAccessLayer dal = new DataAccessLayer(logger);
    dal.AddCustomer("John Smith");
    //dal.AddCustomer("John Smith", "john@example.com");
}


//public class FileLogger
//{
//    public void Log(string message)
//    {
//        // write message to a log file
//    }
//}

//public class DataAccessLayer
//{
//    public void AddCustomer(string name)
//    {
//        // add customer to the database
//        FileLogger logger = new FileLogger();
//        logger.Log("Customer added: " + name);
//    }
//}

public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        // write message to a log file
    }
}

public class DataAccessLayer
{
    private ILogger logger;

    public DataAccessLayer(ILogger logger)
    {
        this.logger = logger;
    }

    public void AddCustomer(string name)
    {
        // add customer to the database
        logger.Log("Customer added: " + name);
    }
}