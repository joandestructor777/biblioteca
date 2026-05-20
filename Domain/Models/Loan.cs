using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Loan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid CopyId { get; set; }
        public Copy Copy { get; set; } = null!;
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public decimal Fine { get; set; }


    }
}
