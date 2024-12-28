using Mango.services.AuthApi.Model.Dto;

namespace Mango.services.AuthApi.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterationRequestDto request);
        Task<LoginResponseDto> Login(LoginRequestDto request);
    }
}
