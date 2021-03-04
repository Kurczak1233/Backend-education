using System;
using System.Collections.Generic;
using System.Text;

namespace Open_Close_Principle_2
{
    class WorkersManager : IWorkersManager
    {
        public Employee CreateEmployee(IApplicant applicant)
        {
            Employee output = new Employee()
            {
                FirstName = applicant.FirstName,
                LastName = applicant.LastName
            };
            return output;
        }
    }
}
