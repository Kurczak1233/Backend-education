using System;
using System.Collections.Generic;

namespace Interfaces_explained
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PhysicalProductModel> cart = AddSampleData();
            CustomerModel customer = GetCustomer();

            foreach(PhysicalProductModel prod in cart)
            {
                prod.ShipItem(customer);
            }

            Console.ReadLine();
        }

        private static CustomerModel GetCustomer()
        {
            return new CustomerModel
            {
                FirstName = "Michal",
                LastName = "Kupczak",
                City = "Bielsko",
                EmailAdress = "hahxdxd@wp.pl",
                PhoneNumber = "555-1111"
            };
        }

        private static List<PhysicalProductModel> AddSampleData()
        {
            List<PhysicalProductModel> output = new List<PhysicalProductModel>();
            output.Add(new PhysicalProductModel { Title = "Nerf ball" });
            output.Add(new PhysicalProductModel { Title = "My stinky t-shirt" });
            output.Add(new PhysicalProductModel { Title = "Hard drive" });
            return output;
        }
        
    }
}
