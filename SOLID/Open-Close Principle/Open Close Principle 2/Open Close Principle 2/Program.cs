using System;
using System.Collections.Generic;
using System.Linq;

namespace Open_Close_Principle_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IApplicant> applicants = new List<IApplicant>()
            {
                new Applicant {FirstName = "Andy", LastName="Dany"},
                new Boss {FirstName = "Michal", LastName="Danil"},
                new Employee {FirstName = "Bob", LastName = "Lukas"}
            };  

        }
    }
}
