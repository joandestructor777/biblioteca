using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Copy
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
        public bool IsAvailable { get; set; } = true;
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
