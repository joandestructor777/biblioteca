using Application.DTOs.AuthorsDTOs;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthorResponseDTO> CreateAuthor(CreateAuthorDTO author)
        {
            var newAuthor = new Author
            {
                Name = author.Name
            };

            var createdAuthor = await _repository.CreateAuthor(newAuthor);

            return new AuthorResponseDTO
            {
                Id = createdAuthor.Id,
                Name = createdAuthor.Name
            };
        }

        public async Task<List<AuthorResponseDTO>> GetAllAuthors()
        {
            var authors = await _repository.GetAllAuthors();

            return authors.Select(author => new AuthorResponseDTO
            {
                Id = author.Id,
                Name = author.Name
            }).ToList();
        }

        public async Task<AuthorResponseDTO?> GetAuthorById(Guid authorId)
        {
            var foundAuthor = await _repository.GetAuthorById(authorId);

            if (foundAuthor == null)
            {
                throw new NotFoundException($"El autor con id: {authorId} no se encontró");
            }

            return new AuthorResponseDTO
            {
                Id = foundAuthor.Id,
                Name = foundAuthor.Name
            };
        }

        public async Task<AuthorResponseDTO?> UpdateAuthor(Guid authorId, UpdateAuthorDTO author)
        {
            var updatedAuthor = await _repository.UpdateAuthor(authorId, new Author
            {
                Name = author.Name
            });

            if (updatedAuthor == null)
            {
                throw new NotFoundException($"El autor con id: {authorId} no se encontró");
            }

            return new AuthorResponseDTO
            {
                Id = updatedAuthor.Id,
                Name = updatedAuthor.Name
            };
        }

        public async Task<AuthorResponseDTO?> DeleteAuthor(Guid authorId)
        {
            var deletedAuthor = await _repository.DeleteAuthor(authorId);

            if (deletedAuthor == null)
            {
                throw new NotFoundException($"El autor con id: {authorId} no se encontró");
            }

            return new AuthorResponseDTO
            {
                Id = deletedAuthor.Id,
                Name = deletedAuthor.Name
            };
        }
    }
}