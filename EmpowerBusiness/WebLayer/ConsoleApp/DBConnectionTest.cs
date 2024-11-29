using System;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public class DBConnectionTest
    {
        private readonly string _connectionString = "Server=VAISHNAV\\SQLEXPRESS;Database=Hangfire;Trusted_Connection=True;TrustServerCertificate=True";

        public void TestConnection()
        {
            using (var connection = new SqlConnection(_connectionString))
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
        }
    }
}
