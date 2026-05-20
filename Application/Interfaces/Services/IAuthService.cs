using Application.DTOs.Auth;

namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginDTO dto);
        Task Register(RegisterDTO dto);
    }
}