using Domain.Enums;

namespace Application.DTOs.Auth
{
    public class RegisterDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public UserRole Role { get; set; }
    }
}