// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

string connectionString = "Server=VAISHNAV\\SQLEXPRESS;Database=Hangfire;Trusted_Connection=True;TrustServerCertificate=True";
using (var connection = new SqlConnection(connectionString))
{
    try
    {
        connection.Open();
        Console.WriteLine("Connection to SQL Server successful.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
