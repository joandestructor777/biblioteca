
using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface ICopyRepository
    {
        public Task<Copy> CreateCopy(Copy copy);
        public Task<IEnumerable<Copy>> GetCopiesByBook(Guid bookId);
        public Task<int> GetAvailableCopies(Guid bookId);
        Task<Copy?> GetAvailableCopy(Guid bookId);
        public Task<Copy?> GetCopyById(Guid copyId);
        public Task<Copy?> UpdateCopy(Copy copy);
        public Task<Copy?> DeleteCopy(Guid copyId);

    }
}
