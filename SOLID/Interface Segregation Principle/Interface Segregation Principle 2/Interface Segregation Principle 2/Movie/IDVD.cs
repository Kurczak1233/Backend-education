using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Segregation_Principle_2
{
    public interface IDVD : ILibraryItem
    {
         List<string> Actors { get; set; }
         int RunTimeInMintes { get; set; }
    }
}
