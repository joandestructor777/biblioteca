using Application.DTOs.CopiesDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;
using Application.Exceptions;

namespace Application.Services
{
    public class CopyService : ICopyService
    {
        private readonly ICopyRepository _repository;
        public CopyService(ICopyRepository repository)
        {
            _repository = repository;
        }

        public async Task<CopyResponseDTO> CreateCopy(CreateCopyDTO copyDto)
        {
            var copy = new Copy
            {
                BookId = copyDto.BookId,
                IsAvailable = true
            };

            var createdCopy = await _repository.CreateCopy(copy);

            return new CopyResponseDTO
            {
                Id = createdCopy.Id,
                BookId = createdCopy.BookId,
                IsAvailable = createdCopy.IsAvailable
            };

        }

        public async Task<IEnumerable<CopyResponseDTO>> GetCopiesByBook(Guid id)
        {
            var copies = await _repository.GetCopiesByBook(id);
            if(copies == null || !copies.Any())
            {
                throw new NotFoundException($"El libro con el id: {id} no tiene copias disponibles.");
            }

            return copies.Select(copy => new CopyResponseDTO
            {
                Id = copy.Id,
                BookId = copy.BookId,
                IsAvailable = copy.IsAvailable
            });
        }

        public async Task<int> GetAvailableCopies(Guid bookId)
        {
            var availables = await _repository.GetAvailableCopies(bookId);
            if(availables == 0)
            {
                throw new NotFoundException($"No hay copias disponibles del libro con id: {bookId}");
            }

            return availables;

        }

        public async Task<Copy?> GetAvailableCopy(Guid bookId)
        {
            return await _repository.GetAvailableCopy(bookId);
        }

        public async Task<CopyResponseDTO> GetCopyById(Guid copyId)
        {
            var copy = await _repository.GetCopyById(copyId);
            if(copy == null)
            {
                throw new NotFoundException($"No se encontró una copia con el id: {copyId}");
            }

            return new CopyResponseDTO
            {
                Id = copy.Id,
                BookId = copy.BookId,
                IsAvailable = copy.IsAvailable
            };
        } 

        public async Task<CopyResponseDTO> UpdateCopy(Guid copyId, UpdateCopyDTO copyDto)
        {
            var foundCopy = await _repository.GetCopyById(copyId);
            if(foundCopy == null)
            {
                throw new NotFoundException($"No se encontró una copia con el id: {copyDto.Id}");
            }

            foundCopy.BookId = copyDto.BookId;
            foundCopy.IsAvailable = copyDto.IsAvailable;

            var updatedCopy = await _repository.UpdateCopy(foundCopy);
            return new CopyResponseDTO
            {
                Id = updatedCopy.Id,
                BookId = updatedCopy.BookId,
                IsAvailable = updatedCopy.IsAvailable
            };

        }

        public async Task<CopyDeleteResponseDTO> DeleteCopy(Guid copyId)
        {
            var foundCopy = await _repository.GetCopyById(copyId);
            if(foundCopy == null)
            {
                throw new NotFoundException($"No se encontro una copia con el id: {copyId}");
            }
            var deletedCopy = await _repository.DeleteCopy(copyId);
            return new CopyDeleteResponseDTO
            {
                Id = deletedCopy.Id
            };

        }
    }
}
