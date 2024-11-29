//Q. What is the difference between “throw ex” and “throw”?
//Throw keyword preserve the whole stack trace and give more information about the error.
//But throw ex will give limited information about the error.

try
{
    DivideZerobyZero();
}
catch (Exception ex)
{
    Console.WriteLine(ex.StackTrace);
    Console.ReadLine();
}
static void DivideZerobyZero()
{
    try
    {
        int i = 0, j = 0;
        int k = i / j;
    }
    catch (Exception ex)
    {
        throw;
    }
}