using Application.DTOs.ReservationsDTOs;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class ReservationService
        : IReservationService
    {
        private readonly IReservationRepository _repository;

        private readonly ICopyRepository _copyRepository;

        public ReservationService(
            IReservationRepository repository,
            ICopyRepository copyRepository)
        {
            _repository = repository;
            _copyRepository = copyRepository;
        }

        public async Task<ReservationResponseDTO?> CreateReservation(CreateReservationDTO dto)
        {
            var availableCopies = await _copyRepository.GetAvailableCopies(dto.BookId);

            if (availableCopies > 0)
            {
                throw new BaseException("Este libro tiene copias disponibles",400);
            }

            var reservation = new Reservation
            {
                UserId = dto.UserId,
                BookId = dto.BookId,
                ReservationDate = DateTime.UtcNow
            };

            await _repository.CreateReservation(reservation);

            return new ReservationResponseDTO
            {
                Id = reservation.Id,
                UserId = reservation.UserId,
                BookId = reservation.BookId,
                ReservationDate =reservation.ReservationDate
            };
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            var reservations = await _repository.GetAllReservations();

            if (!reservations.Any())
            {
                throw new NotFoundException("No hay reservas registradas");
            }

            return reservations;
        }

        public async Task<Reservation?> GetReservationById(Guid reservationId)
        {
            var reservation = await _repository.GetReservationById(reservationId);

            if (reservation == null)
            {
                throw new NotFoundException($"La reserva con id {reservationId} no existe");
            }

            return reservation;
        }
    }
}