
using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User?> GetUserById(Guid userId)
        {
            var foundUser = await _context.Users.FindAsync(userId);
            if (foundUser == null) return null;
            return foundUser;
        }
        public async Task<List<User>?> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            if(foundUser == null) return null;
            return foundUser;
        }
        public async Task<User?> UpdateUser(Guid userId, User user)
        {
            var foundUser = await _context.Users.FindAsync(userId);
            if (foundUser == null) return null;
            foundUser.Name = user.Name;
            foundUser.Email = user.Email;
            foundUser.PasswordHash = user.PasswordHash;
            foundUser.Role = user.Role;

            _context.Users.Update(foundUser);
            await _context.SaveChangesAsync();
            return foundUser;
        }
        public async Task<User?> DeleteUser(Guid userId)
        {
            var foundUser = await _context.Users.FindAsync(userId);
            if (foundUser == null) return null;
            _context.Users.Remove(foundUser);
            await _context.SaveChangesAsync();
            return foundUser;
        }

    }
}
