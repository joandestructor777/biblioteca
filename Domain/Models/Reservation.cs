namespace Domain.Models
{
    public class Reservation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
        public DateTime ReservationDate { get; set; }
        public bool IsCompleted { get; set; } = false;

    }
}