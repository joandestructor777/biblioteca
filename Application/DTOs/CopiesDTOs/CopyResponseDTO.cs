
namespace Application.DTOs.CopiesDTOs
{
    public class CopyResponseDTO
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
