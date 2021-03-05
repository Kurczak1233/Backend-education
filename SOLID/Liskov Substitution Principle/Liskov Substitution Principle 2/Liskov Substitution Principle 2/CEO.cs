using System;
using System.Collections.Generic;
using System.Text;

namespace Liskov_Substitution_Principle_2
{
    class CEO : BaseEmployee, IManager
    {
        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 150M;
            Salary = baseAmount * rank;

        }

        public void GeneratePerformanceReview()
        {
            Console.WriteLine("Performance simulator...");
        }

        public void FireSomeone()
        {
            Console.WriteLine("You're fired!");
        }

    }
}
