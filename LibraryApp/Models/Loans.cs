using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Loans
    {
        int Id { get; set; }
        int BookId { get; set; }
        int CustomerId { get; set; }
        DateTime LoanDate { get; set; }
        DateTime ReturnDate { get; set; }
    }
}
