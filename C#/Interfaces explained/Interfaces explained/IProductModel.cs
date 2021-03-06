using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_explained
{
    public interface IProductModel
    {
        string Title { get; set; }
        bool HasOrderBeenCompleted { get; set; }
        void ShipItem(CustomerModel customer);
    }
}
