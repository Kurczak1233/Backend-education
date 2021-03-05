using System;
using System.Collections.Generic;
using System.Text;

namespace Liskov_Substitution_Principle_2
{
    public class Employee
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public Employee Manager { get; set; } = null;

        public decimal Salary { get; set; }

        public virtual void AssingManager(Employee manager)
        {
            Manager = manager;
        }

        public virtual void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 12.50M;
            Salary = baseAmount + (rank * 2);
        }
    }
}
