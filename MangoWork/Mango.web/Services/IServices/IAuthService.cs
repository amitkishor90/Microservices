using Mango.web.Models;

namespace Mango.web.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> Login(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterUser(RegisterationRequestDto registerationRequestDto);
        Task<ResponseDto?> AssignRole(RegisterationRequestDto registerationRequestDto);
    }
}
