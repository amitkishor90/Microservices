

using Mango.web.Models;
using Mango.web.Utility;
using static Mango.web.Utility.SD;

namespace Mango.web.Services.IServices
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> AssignRole(RegisterationRequestDto registerationRequestDto)
        {
           return await _baseService.sendAsync(new RequestDto
           {
               ApiType = ApiType.POST,
               url = AuthAPIBase + "/api/AuthAPI/AssignRole",
               AccessToken = "",
               Data = registerationRequestDto
           }, true);
        }

        public async Task<ResponseDto?> Login(LoginRequestDto loginRequestDto)
        {
            return await _baseService.sendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                url = SD.AuthAPIBase + "/api/AuthAPI/login"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterUser(RegisterationRequestDto registerationRequestDto)
        {
            return await _baseService.sendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registerationRequestDto,
                url = SD.AuthAPIBase + "/api/AuthAPI/register"
            }, false);
        }
    }
}
