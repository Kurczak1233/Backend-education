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
                CreateCommand.Parameters.AddWithValue("firstName", "Michał"); //First crucial defend against SQL Injections!
                CreateCommand.Parameters.AddWithValue("lastName", "Kupczak");
                var Create = CreateCommand.ExecuteNonQuery();
                //READ                 
                var ReadingCommand = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                Console.WriteLine(ReadingCommand.ExecuteScalar());

                var ReadingCommand2 = new SqlCommand("SELECT TOP(10) o.EmployeeID [Worker's ID], c.CustomerID [Customer's ID] " +
                    "FROM Orders o JOIN Customers c ON o.CustomerID = c.CustomerID", connection);
                var Read = ReadingCommand2.ExecuteReader();
                while (Read.Read())
                {
                    Console.WriteLine("{0} {1}",
                       Read[0],
                       Read[1]);
                }
                //UPDATE
                var UpdateCommand = new SqlCommand("UPDATE Employees SET FirstName=@name WHERE EmployeeId=@Id", connection);
                UpdateCommand.Parameters.AddWithValue("name", "Kicia");
                UpdateCommand.Parameters.AddWithValue("id", "10");
                var Update = UpdateCommand.ExecuteNonQuery();
                //DELETE
                var DeleteCommand = new SqlCommand("DELETE FROM Employees WHERE EmployeeId=@Id", connection);
                DeleteCommand.Parameters.AddWithValue("Id", "11");
                var Delete = DeleteCommand.ExecuteNonQuery();
            }
        }
    }
}
