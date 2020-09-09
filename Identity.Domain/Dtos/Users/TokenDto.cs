using System;

namespace Identity.Domain.Dtos.Users
{
    public class TokenDto
    {
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        public string Token { get; set; }
    }
}
