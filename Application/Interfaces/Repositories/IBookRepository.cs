using Application.DTOs.BooksDTOs;
using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<Book> CreateBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBook(int id);
        Task<Book?> UpdateBook(int id, Book book);
        Task<Book?> DeleteBook(int id);
        Task<Book?> GetBookByTitle(string title);
        Task<Book?> GetBookByISBN(string isbn);
        Task<List<Book>> GetBookByPublicationYear(int year);
        Task<List<Book>> GetBookByCategory(Guid categoryId);
        Task<Book?> DeleteBook(Guid id);



    }
}
