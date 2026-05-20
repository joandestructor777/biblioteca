using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation?> CreateReservation(Reservation reservation);

        Task<List<Reservation>> GetAllReservations();

        Task<Reservation?> GetReservationById(Guid reservationId);
    }
}