using System;
using System.Data.SqlClient;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "Server=FLUTTERSHY\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true";
            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                //CREATE
                var CreateCommand = new SqlCommand("INSERT INTO Employees(FirstName, LastName) values(@firstName, @lastName)", connection);
                CreateCommand.Parameters.AddWithValue("firstName", "Michał");
                CreateCommand.Parameters.AddWithValue("lastName", "Kupczak");
                var Create = CreateCommand.ExecuteNonQuery();
                //READ                 
                var command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                Console.WriteLine(command.ExecuteScalar());

                var command2 = new SqlCommand("SELECT TOP(10) o.EmployeeID [Worker's ID], c.CustomerID [Customer's ID] " +
                    "FROM Orders o JOIN Customers c ON o.CustomerID = c.CustomerID", connection);
                var reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1}",
                       reader[0],
                       reader[1]);
                }
                //UPDATE

                //DELETE


            }
        }
    }
}
