using System;

namespace Liskov_Substitution_Principle_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager accountiongVp = new Manager();
            accountiongVp.FirstName = "Emma";
            accountiongVp.LastName = "Emma";
            accountiongVp.CalculatePerHourRate(4);

            Employee emp = new Manager();

            emp.FirstName = "Michal";
            emp.LastName = "Kupczak";
            emp.AssingManager(accountiongVp);
            emp.CalculatePerHourRate(2);

            Console.WriteLine($"{emp.FirstName}'s salary is ${emp.Salary}/hour.");

            Console.ReadLine();

        }
    }
}
