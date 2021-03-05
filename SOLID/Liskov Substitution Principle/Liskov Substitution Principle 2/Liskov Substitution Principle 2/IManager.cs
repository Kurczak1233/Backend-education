using System;
using System.Collections.Generic;
using System.Text;

namespace Liskov_Substitution_Principle_2
{
    public interface IManager : IEmployee
    {
        void GeneratePerformanceReview();
    }
}
