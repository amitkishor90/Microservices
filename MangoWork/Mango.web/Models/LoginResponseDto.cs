using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Mango.web.Models
{
    public class LoginResponseDto
    {
        [Required]
        public UserDto User { get; set; }
        [Required]
        public string Token { get; set; }   
    }
}
