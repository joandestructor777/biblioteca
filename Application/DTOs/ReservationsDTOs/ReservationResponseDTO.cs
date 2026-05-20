
namespace Application.DTOs.ReservationsDTOs
{
    public class ReservationResponseDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime ReservationDate {  get; set; }
    }
}
