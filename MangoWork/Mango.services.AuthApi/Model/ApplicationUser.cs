using Microsoft.AspNetCore.Identity;

namespace Mango.services.AuthApi.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
