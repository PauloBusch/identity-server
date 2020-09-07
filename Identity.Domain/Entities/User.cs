using Identity.Domain._Common.Entities;
using System;

namespace Identity.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        protected User() { }

        public User(
            Guid? id,
            string name,
            string email
        ) : this()
        {
            CreatedAt = DateTime.UtcNow;
            Id = id ?? Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public void Change(
            string name,
            string email
        ) {
            UpdatedAt = DateTime.UtcNow;
            Name = name;
            Email = email;
        }
    }
}
