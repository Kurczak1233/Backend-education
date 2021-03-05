using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Segregation_Principle_2
{
    public class RefenceBook : ILibraryItem
    {
        public string LibraryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int CheckOutDurationInDays { get; set; }
        public string Borrower { get; set; }
        public DateTime BorrowDate { get; set; }

        public void CheckOut(string borrower)
        {
            //
        }

        public void CheckIn()
        {
            //
        }

        public DateTime GetDueDate()
        {
            DateTime time = new DateTime(2001, 2, 5);
            return time;
        }
    }
}
