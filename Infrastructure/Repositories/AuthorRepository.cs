using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author?> GetAuthorById(Guid authorId)
        {
            return await _context.Authors.FirstOrDefaultAsync(author => author.Id == authorId);
        }

        public async Task<Author?> UpdateAuthor(Guid authorId, Author author)
        {
            var foundAuthor = await _context.Authors.FirstOrDefaultAsync(author => author.Id == authorId);
            if (foundAuthor == null)
            {
                return null;
            }

            foundAuthor.Name = author.Name;
            await _context.SaveChangesAsync();

            return foundAuthor;
        }

        public async Task<Author?> DeleteAuthor(Guid authorId)
        {
            var foundAuthor = await _context.Authors.FirstOrDefaultAsync(author => author.Id == authorId);
            if (foundAuthor == null)
            {
                return null;
            }

            _context.Authors.Remove(foundAuthor);
            await _context.SaveChangesAsync();

            return foundAuthor;
        }
    }
}