using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> GetByEmail(string email);
        Task<User> Create(User user);
        Task<List<User>> GetAll();

    }
}