using Application.DTOs.AuthorsDTOs;

namespace Application.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<AuthorResponseDTO> CreateAuthor(CreateAuthorDTO author);
        Task<List<AuthorResponseDTO>> GetAllAuthors();
        Task<AuthorResponseDTO?> GetAuthorById(Guid authorId);
        Task<AuthorResponseDTO?> UpdateAuthor(Guid authorId, UpdateAuthorDTO author);
        Task<AuthorResponseDTO?> DeleteAuthor(Guid authorId);
    }
}