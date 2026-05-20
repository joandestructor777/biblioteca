using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
