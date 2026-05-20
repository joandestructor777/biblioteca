
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.CopiesDTOs;

namespace Infrastructure.Repositories
{
    public class CopyRepository : ICopyRepository
    {
        private readonly AppDbContext _context;
        public CopyRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Copy> CreateCopy(Copy copy)
        {
            await _context.AddAsync(copy);
            await _context.SaveChangesAsync();
            return copy;
        }

        public async Task<IEnumerable<Copy>> GetCopiesByBook(Guid bookId)
        {
            return await _context.Copies
                .Where(copies => copies.BookId == bookId)
                .ToListAsync();            
        }

        public async Task<int> GetAvailableCopies(Guid bookId)
        {
            var availableCopies = await _context.Copies
                .Where(copies => copies.BookId == bookId && copies.IsAvailable)
                .ToListAsync();
            return availableCopies.Count;
        }

        public async Task<Copy?> GetAvailableCopy(Guid bookId)
        {
            return await _context.Copies
                .FirstOrDefaultAsync(book =>
                    book.BookId == bookId &&
                    book.IsAvailable);
        }


        public async Task<Copy?> GetCopyById(Guid id)
        {
            var foundCopy = await _context.Copies.FindAsync(id);
            if (foundCopy == null) return null;
            return foundCopy;

        }

        public async Task<Copy?> UpdateCopy(Copy copy)
        {
            var foundCopy = await _context.Copies.FindAsync(copy.Id);
            if(foundCopy == null) return null;
            foundCopy.BookId = copy.BookId;
            foundCopy.IsAvailable = copy.IsAvailable;
            await _context.SaveChangesAsync();
            return copy;
        }

        public async Task<Copy?> DeleteCopy(Guid copyId)
        {
            var foundCopy = await _context.Copies.FindAsync(copyId);
            if(foundCopy == null) return null;
            _context.Remove(foundCopy);
            await _context.SaveChangesAsync();
            return foundCopy;
        } 
    }
}
