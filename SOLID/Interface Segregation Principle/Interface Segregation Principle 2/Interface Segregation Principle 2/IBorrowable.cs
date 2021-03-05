using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Segregation_Principle_2
{
    public interface IBorrowable
    {
        DateTime BorrowDate { get; set; }
        string Borrower { get; set; }
        int CheckOutDurationInDays { get; set; }


        void CheckIn();
        void CheckOut(string borrower);
        DateTime GetDueDate();
    }
}
