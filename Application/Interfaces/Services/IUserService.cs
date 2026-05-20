
using Application.DTOs.UsersDTOs;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseDTO> CreateUser(CreateUserDTO user);
        Task<UserResponseDTO?> GetUserById(Guid userId);
        Task<List<UserResponseDTO>?> GetAllUsers();
        Task<UserResponseDTO?> GetUserByEmail(string email);
        Task<UserResponseDTO?> UpdateUser(Guid userId, UpdateUserDTO user);
        Task<UserResponseDTO?> DeleteUser(Guid userId);
    }
}
