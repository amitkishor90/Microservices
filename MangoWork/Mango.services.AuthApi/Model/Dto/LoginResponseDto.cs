﻿namespace Mango.services.AuthApi.Model.Dto
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }   
    }
}
