using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> CreateAuthor(Author author);
        Task<List<Author>> GetAllAuthors();
        Task<Author?> GetAuthorById(Guid authorId);
        Task<Author?> UpdateAuthor(Guid authorId, Author author);
        Task<Author?> DeleteAuthor(Guid authorId);
    }
}
