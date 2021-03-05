using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Segregation_Principle_2
{
    public interface IBook : ILibraryItem
    {
        string Author { get; set; }
        int Pages { get; set; }
    }
}
