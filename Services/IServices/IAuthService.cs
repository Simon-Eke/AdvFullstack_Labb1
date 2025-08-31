using AdvFullstack_Labb1.Models.DTOs;

namespace AdvFullstack_Labb1.Services.IServices
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(string username, string password);
    }
}
