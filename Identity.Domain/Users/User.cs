using Identity.Domain.Utils.Common;
using System;

namespace Identity.Domain.Users
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public User(
            Guid? id,
            string name,
            string password
        ) : base(id ?? Guid.NewGuid()) { 
            Name = name;
            PasswordHash = password;
        }
    }
}
