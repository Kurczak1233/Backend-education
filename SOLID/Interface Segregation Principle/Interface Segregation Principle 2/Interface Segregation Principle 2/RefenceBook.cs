using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Segregation_Principle_2
{
    public class RefenceBook : IBook
    {
        public string LibraryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
    }
}
