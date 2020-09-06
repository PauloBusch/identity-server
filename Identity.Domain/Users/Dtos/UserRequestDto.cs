using System;

namespace Identity.Domain.Users.Dtos
{
    public class UserRequestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
