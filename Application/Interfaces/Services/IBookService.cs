using Application.DTOs.BooksDTOs;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IBookService
    {
        public Task<BookResponseDTO> CreateBook(CreateBookDTO book);
        public Task<IEnumerable<BookResponseDTO>> GetAllBooks();
        public Task<BookResponseDTO> GetBook(int id);
        public Task<BookResponseDTO> UpdateBook(int id, UpdateBookDTO book);
        public Task<DeleteBookResponseDTO> DeleteBook(int id);
        public Task<BookResponseDTO> GetBookByTitle(string title);
        public Task<BookResponseDTO> GetBookByISBN(string isbn);
        public Task<IEnumerable<BookResponseDTO>> GetBookByPublicationYear(int year);
        public Task<IEnumerable<BookResponseDTO>> GetBookByCategory(Guid categoryId);
        public Task<DeleteBookResponseDTO> DeleteBook(Guid id);
    }
}
