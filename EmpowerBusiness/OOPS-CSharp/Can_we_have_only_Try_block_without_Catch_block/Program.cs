using System.Data.SqlClient;

//Q.Can we have only “Try” block without “Catch” block?

SqlConnection con = new SqlConnection("conString");
try
{
    con.Open();
    Random rnd = new Random();
    int num = rnd.Next();

    if (num == 5)
    {
        return;
        //After this nothing will execute
    }
    //con.Close();                
}
finally
{
    con.Close();
}