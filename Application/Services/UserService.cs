
using Application.DTOs.UsersDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;
using Application.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly PasswordHasher<User> _hasher;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
            _hasher = new PasswordHasher<User>();
        }

        public async Task<UserResponseDTO> CreateUser(CreateUserDTO user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
            newUser.PasswordHash = _hasher.HashPassword(newUser, user.PasswordHash);


            var createdUser = await _repository.CreateUser(newUser);
            return new UserResponseDTO
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email,
                Role = createdUser.Role,

                
            };
        }

        public async Task<UserResponseDTO?> GetUserById(Guid userId)
        {
            var foundUser = await _repository.GetUserById(userId);
            if (foundUser == null)
            {
                throw new NotFoundException($"El usuario con id: {userId} no se encuentra");
            }
            return new UserResponseDTO
            {
                Id = foundUser.Id,
                Name = foundUser.Name,
                Email = foundUser.Email,
                Role = foundUser.Role
            };
        }
        public async Task<List<UserResponseDTO>?> GetAllUsers() 
        {
            var users = await _repository.GetAllUsers();
            if (users == null) { 
                throw new NotFoundException("No se encontraron usuarios");
            }
            return users.Select(u => new UserResponseDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
            }).ToList();
        }
        public async Task<UserResponseDTO?> GetUserByEmail(string email)
        {
            var foundUser = await _repository.GetUserByEmail(email);
            if(foundUser == null) { 
                throw new NotFoundException($"El usuario con email: {email} no se encuentra");
            }
            return new UserResponseDTO
            {
                Id = foundUser.Id,
                Name = foundUser.Name,
                Email = foundUser.Email,
                Role = foundUser.Role
            };
        }

        public async Task<UserResponseDTO?> UpdateUser(Guid userId, UpdateUserDTO user)
        {
            var updatedUser = await _repository.UpdateUser(userId, new User
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Role = user.Role
            });

            if (updatedUser == null) 
            {
                throw new NotFoundException($"El usuario con id: {userId} no se encuentra");
            }

            return new UserResponseDTO
            {
                Id = updatedUser.Id,
                Name = updatedUser.Name,
                Email = updatedUser.Email,
                Role = updatedUser.Role
            };
        }
        public async Task<UserResponseDTO?> DeleteUser(Guid userId)
        {
            var deletedUser = await _repository.DeleteUser(userId);
            if (deletedUser == null)
            {
                throw new NotFoundException($"El usuario con id: {userId} no se encuentra");
            }

            return new UserResponseDTO
            {
                Id = deletedUser.Id,
                Name = deletedUser.Name,
                Email = deletedUser.Email,
                Role = deletedUser.Role

            };
        }


    }
}