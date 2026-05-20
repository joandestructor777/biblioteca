using Application.DTOs.Auth;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Enums;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly PasswordHasher<User> _hasher;
        private readonly IConfiguration _config;

        public AuthService(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
            _hasher = new PasswordHasher<User>();
        }

        public async Task Register(RegisterDTO dto)
        {
            var existingUser = await _repo.GetByEmail(dto.Email);
            if (existingUser != null)
                throw new Exception("El email ya está registrado");
            var users = await _repo.GetAll();

            var role = users.Any()
                ? UserRole.Reader
                : UserRole.Admin;
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Role = role 
            };

            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            await _repo.Create(user);
        }

        public async Task<string> Login(LoginDTO dto)
        {
            var user = await _repo.GetByEmail(dto.Email);

            if (user == null)
                throw new NotFoundException("Usuario no encontrado");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result != PasswordVerificationResult.Success)
                throw new Exception("Credenciales inválidas");

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}