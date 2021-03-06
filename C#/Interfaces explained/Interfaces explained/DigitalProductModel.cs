using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_explained
{
    public class DigitalProductModel
    {
        public string Title { get; set; }

        public void ShipItem(CustomerModel customer)
        {
            Console.WriteLine($"Simulating shipping {Title} to {customer.EmailAdress} in {customer.City}");
        }
    }
}
