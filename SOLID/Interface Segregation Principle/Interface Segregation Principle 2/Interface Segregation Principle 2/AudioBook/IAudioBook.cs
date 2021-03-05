using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Segregation_Principle_2
{
    public interface IAudioBook : ILibraryItem
    {
        int RunTimeInMinutes { get; set; }
    }
}
