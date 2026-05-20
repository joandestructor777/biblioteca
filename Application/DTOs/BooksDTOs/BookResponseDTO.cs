namespace Application.DTOs.BooksDTOs
{
    public class BookResponseDTO
    {
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public Guid CategoryId { get; set; }
    }
}
