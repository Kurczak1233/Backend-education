using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Segregation_Principle_2
{
    class DVD : ILibraryItem
    {
        public string Author { get; set; }
        public DateTime BorrowDate { get; set; }
        public string Borrower { get; set; }
        public int CheckOutDurationInDays { get; set; }
        public string LibraryId { get; set; }
        public int Pages { get; set; }
        public string Title { get; set; }
        public int RunTimeInMinutes { get; set; }
        
        public List<string> Actors { get; set; }
        public int RunTimeInMintes { get; set; }
        public void CheckIn()
        {
            throw new NotImplementedException();
        }

        public void CheckOut(string borrower)
        {
            BorrowDate = DateTime.Now;
            Borrower = borrower;
        }

        public DateTime GetDueDate()
        {
            throw new NotImplementedException();
        }
    }
}
