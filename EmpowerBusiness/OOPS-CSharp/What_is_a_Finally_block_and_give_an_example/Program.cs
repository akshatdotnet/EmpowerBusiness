//Finally block will be executed IRRESPECTIVE of exception.

using System.Data.SqlClient;

static void Main(string[] args)
{
    SqlConnection con = new SqlConnection("conString");
    try
    {
        con.Open();

        //Some logic

        // Error occurred

        //con.Close();
    }
    catch (Exception ex)
    {
        // error handled 
    }
    finally
    {
        // Connection closed  
        con.Close();
    }
}