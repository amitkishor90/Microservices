using Mango.services.AuthApi.Model;

namespace Mango.services.AuthApi.IService
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
