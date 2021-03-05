using System;
using System.Collections.Generic;
using System.Text;

namespace Liskov_Substitution_Principle_2
{
    public interface IManaged : IEmployee
    {
         IEmployee Manager { get; set; }
         void AssingManager(IEmployee manager);
    }
}
