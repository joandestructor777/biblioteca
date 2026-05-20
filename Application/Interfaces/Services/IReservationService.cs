using Application.DTOs.ReservationsDTOs;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IReservationService
    {
        Task<ReservationResponseDTO?> CreateReservation(CreateReservationDTO dto);
        Task<List<Reservation>> GetAllReservations();
        Task<Reservation?> GetReservationById(Guid reservationId);
    }
}