
using Domain.Enums;

namespace Application.DTOs.UsersDTOs
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public  string Email { get; set; }
        public UserRole Role { get; set; } 
    }
}
