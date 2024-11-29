//Exception handling in Object-Oriented Programming is used to MANAGE ERRORS. 


try
{
    int i = 1;
    int j = 1;

    int k = i / j;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);

    throw;
}
finally
{
    Console.WriteLine("Finally");
    Console.ReadLine();
}