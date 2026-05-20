using Application.DTOs.BooksDTOs;
using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<Book> CreateBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBook(int id)
        {
            var foundBook = await _context.Books.FindAsync(id);
            if(foundBook != null)
            {
                return foundBook;
            }
            return null;
        }

        public async Task<Book?> UpdateBook(int id, Book book)
        {
            var foundBook = await _context.Books.FindAsync(id);
            if (foundBook == null) return null;
            
            foundBook.Title = book.Title;
            foundBook.ISBN = book.ISBN;
            foundBook.PublicationYear = book.PublicationYear;
            foundBook.CategoryId = book.CategoryId;

            await _context.SaveChangesAsync();
            return foundBook;
        }

        public async Task<Book?> DeleteBook(int id)
        {
            var foundBook = await _context.Books.FindAsync(id);
            if (foundBook == null) return null;

            _context.Books.Remove(foundBook);
            await _context.SaveChangesAsync();
            return foundBook;
        }

        public async Task<Book?> GetBookByTitle(string title)
        {
            var foundBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == title);
            if (foundBook != null)
            {
                return foundBook;
            }
            return null;
        }

        public async Task<Book?> GetBookByISBN(string isbn)
        {
            var foundBook = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
            if (foundBook != null)
            {
                return foundBook;
            }
            return null;
        }
        public async Task<List<Book>> GetBookByPublicationYear(int year)
        {
            return await _context.Books
                .Where(book => book.PublicationYear == year)
                .ToListAsync();
        }
        public async Task<List<Book>> GetBookByCategory(Guid categoryId)
        {
            return await _context.Books
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Book?> DeleteBook(Guid id)
        {
            var foundBook = await _context.Books.FindAsync(id);

            if (foundBook == null)
            {
                return null;
            }

            _context.Books.Remove(foundBook);

            await _context.SaveChangesAsync();

            return foundBook;
        }
    }
}
