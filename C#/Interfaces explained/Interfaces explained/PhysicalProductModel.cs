using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_explained
{
    public class PhysicalProductModel
    {
        public string Title{ get; set; }
        public bool HasOrderBeenCompleted { get; private set; }

        public void ShipItem(CustomerModel customer)
        {
            if(HasOrderBeenCompleted == false)
            {
                Console.WriteLine($"Simulating shipping {Title} to {customer.FirstName} in {customer.City}");
                HasOrderBeenCompleted = true;
            }
        }
    }
}
