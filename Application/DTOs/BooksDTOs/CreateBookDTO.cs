
namespace Application.DTOs.BooksDTOs
{
    public class CreateBookDTO
    {
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public Guid CategoryId { get; set; }
        public List<Guid> AuthorIds { get; set; } = new();
    }
}
