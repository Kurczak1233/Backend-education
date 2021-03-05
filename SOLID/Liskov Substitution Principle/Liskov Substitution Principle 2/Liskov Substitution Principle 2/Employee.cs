using System;
using System.Collections.Generic;
using System.Text;

namespace Liskov_Substitution_Principle_2
{
    public class Employee : BaseEmployee, IManaged
    {
        //Intefaces props, not inherited further.
        public IEmployee Manager { get; set; } = null;
        public virtual void AssingManager(IEmployee manager)
        {
            Manager = manager;
        }
    }
}
