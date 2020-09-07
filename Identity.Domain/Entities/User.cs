using Identity.Domain._Common.Entities;

namespace Identity.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        protected User() { }
    }
}
