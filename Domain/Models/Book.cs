

namespace Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<Copy> Copies { get; set; } = new List<Copy>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();  
    }
}
