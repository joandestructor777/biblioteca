using Application.DTOs.CopiesDTOs;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface ICopyService
    {
        public Task<CopyResponseDTO> CreateCopy(CreateCopyDTO copyDto);
        public Task<IEnumerable<CopyResponseDTO>> GetCopiesByBook(Guid bookId);  
        public Task<int> GetAvailableCopies(Guid bookId);
        Task<Copy?> GetAvailableCopy(Guid bookId);
        public Task<CopyResponseDTO> GetCopyById(Guid copyId);
        public Task<CopyResponseDTO> UpdateCopy(Guid copyId, UpdateCopyDTO copyDto);
        public Task<CopyDeleteResponseDTO> DeleteCopy(Guid copyId);

    }
}
