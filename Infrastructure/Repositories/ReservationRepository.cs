using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;

        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation?> CreateReservation( Reservation reservation)
        {
            await _context.Reservations
                .AddAsync(reservation);

            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            return await _context.Reservations
                .Include(x => x.User)
                .Include(x => x.Book)
                .ToListAsync();
        }

        public async Task<Reservation?> GetReservationById(Guid reservationId)
        {
            return await _context.Reservations
                .Include(x => x.User)
                .Include(x => x.Book)
                .FirstOrDefaultAsync(
                    x => x.Id == reservationId);
        }
    }
}