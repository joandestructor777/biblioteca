
using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> CreateUser(User user);
        Task<User?> GetUserById(Guid userId);
        Task<List<User>?> GetAllUsers();
        Task<User?> GetUserByEmail(string email);
        Task<User?> UpdateUser(Guid userId, User user);
        Task<User?> DeleteUser(Guid userId);
    }
}
