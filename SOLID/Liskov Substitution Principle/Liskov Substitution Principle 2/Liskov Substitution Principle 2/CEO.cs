using System;
using System.Collections.Generic;
using System.Text;

namespace Liskov_Substitution_Principle_2
{
    class CEO : Employee
    {
        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 150M;
            Salary = baseAmount * rank;

        }

        public override void AssingManager(Employee manager)
        {
            throw new InvalidOperationException("The CEO has no manager.");
        }

        public void GeneratePerfomranceReview()
        {
            Console.WriteLine("Performance simulator...");
        }

        public void FireSomeone()
        {
            Console.WriteLine("You're fired!");
        }

    }
}
