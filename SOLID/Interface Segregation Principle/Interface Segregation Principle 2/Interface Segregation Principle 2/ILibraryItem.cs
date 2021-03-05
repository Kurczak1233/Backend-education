using System;

namespace Interface_Segregation_Principle_2
{
    public interface ILibraryItem
    {
        string LibraryId { get; set; }
        string Title { get; set; }
    }
}