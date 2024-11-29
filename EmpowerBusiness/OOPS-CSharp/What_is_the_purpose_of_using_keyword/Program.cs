﻿//Q. What is the purpose of “using” keyword in C#?
//There are two purpose of using keyword in C#:
//USING DIRECTIVE
//USING STATEMENT  - The using statement ensures that DISPOSE() method is called even if an exception occurs.
//The using statement defines a scope at the end of which an object will be disposed.


using System.Data.SqlClient;

using (var connection = new SqlConnection("ConnectionString"))
{
    var query = "UPDATE YourTable SET Property = Value";
    var command = new SqlCommand(query, connection);

    connection.Open();
    command.ExecuteNonQuery();

    //connection.Dispose();
}