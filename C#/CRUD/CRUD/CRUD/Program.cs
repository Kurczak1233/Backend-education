using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CRUD
{
    class Program
    {
        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DateOfBirth { get; set; }

            //public Employee(string fn, string ln, string dt)
            //{
            //    FirstName = fn;
            //    LastName = ln;
            //    DateOfBirth = dt;
            //}
        }

        static void Main(string[] args)
        {
            string constr = "Server=FLUTTERSHY\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true";
            //
            DateTime date = new DateTime(1950, 5, 2);
            WyswietlStarszychNiz(date);
            //Employee Test = new Employee("Daniel", "Biegun", "1994-04-03");
            //

            using (var connection = new SqlConnection(constr))
            {
                //CREATE
                //var CreateCommand = new SqlCommand("INSERT INTO Employees(FirstName, LastName, BirthDate) values(@firstName, @lastName, @dateOfBirth)", connection);
                //CreateCommand.Parameters.AddWithValue("firstName", Test.FirstName); //First crucial defend against SQL Injections!
                //CreateCommand.Parameters.AddWithValue("lastName", Test.LastName);
                //CreateCommand.Parameters.AddWithValue("dateOfBirth", Test.DateOfBirth);
                //var Create = CreateCommand.ExecuteNonQuery();
                ////READ                 
                //var ReadingCommand = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                //Console.WriteLine(ReadingCommand.ExecuteScalar());

                //var ReadingCommand2 = new SqlCommand("SELECT TOP(10) o.EmployeeID [Worker's ID], c.CustomerID [Customer's ID] " +
                //    "FROM Orders o JOIN Customers c ON o.CustomerID = c.CustomerID", connection);
                //var Read = ReadingCommand2.ExecuteReader();
                //while (Read.Read())
                //{
                //    Console.WriteLine("{0} {1}",
                //       Read[0],
                //       Read[1]);
                //}
                ////UPDATE
                //var UpdateCommand = new SqlCommand("UPDATE Employees SET FirstName=@name WHERE EmployeeId=@Id", connection);
                //UpdateCommand.Parameters.AddWithValue("name", "Kicia");
                //UpdateCommand.Parameters.AddWithValue("id", "10");
                //var Update = UpdateCommand.ExecuteNonQuery();
                ////DELETE
                //var DeleteCommand = new SqlCommand("DELETE FROM Employees WHERE EmployeeId=@Id", connection);
                //DeleteCommand.Parameters.AddWithValue("Id", "17");
                //var Delete = DeleteCommand.ExecuteNonQuery();



                //var ReadCommand3 = new SqlCommand("SELECT * FROM Employees", connection);  //Wyśietlenie imion
                //var EmployeesList = ReadCommand3.ExecuteReader();
                //List<Employee> EmployeeList = new List<Employee>();
                //while (EmployeesList.Read())
                //{
                //    Employee employee = new Employee(EmployeesList[0].ToString(), EmployeesList[1].ToString(), EmployeesList[2].ToString());
                //    EmployeeList.Add(employee);
                //}
                //Employee[] employees = connection.Query<Employee>("select * from Employees").ToArray();
                var Result = connection.Execute("INSERT INTO Employees(FirstName, LastName) values(@firstName, @lastName)", new { FirstName = "John", LastName = "Kowalsky" });
            }
        }

        public static void WyswietlStarszychNiz(DateTime rokUrodzenia)
        {
            string constr = "Server=FLUTTERSHY\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true";
            using (var connection = new SqlConnection(constr))
            {
                var Employees = connection.Query<Employee>(" select * from Employees where BirthDate < @Param", new { Param = rokUrodzenia });
                foreach (var item in Employees)
                {
                    Console.WriteLine(item.FirstName + ' ' + item.LastName + ' ' + item.DateOfBirth);
                }
            }
        }
    }
}
