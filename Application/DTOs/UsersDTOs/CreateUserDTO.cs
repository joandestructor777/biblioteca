
using Domain.Enums;

namespace Application.DTOs.UsersDTOs
{
    public class CreateUserDTO
    {
        public required string Name {  get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public UserRole Role { get; set; }

    }
}
