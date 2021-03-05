using System;

namespace Liskov_Substitution_Principle_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IManager accountiongVp = new CEO();
            accountiongVp.FirstName = "Emma";
            accountiongVp.LastName = "Emma";
            accountiongVp.CalculatePerHourRate(4);

            BaseEmployee emp = new Manager();

            emp.FirstName = "Michal";
            emp.LastName = "Kupczak";
            //emp.AssingManager(accountiongVp);
            emp.CalculatePerHourRate(2);
            Console.WriteLine($"{emp.FirstName}'s salary is ${emp.Salary}/hour.");

            Console.ReadLine();

        }
    }
}
