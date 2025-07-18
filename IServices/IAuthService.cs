using API_REST_PROYECT.DTOs.Auth;
using API_REST_PROYECT.Models;

namespace API_REST_PROYECT.IServices
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(RegisterDto dto);

        Task<string?> LoginUser(LoginDto dto);

        Task<bool> ConfirmEmailAsync(string token);

    }
}
