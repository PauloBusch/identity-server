using Identity.Domain.Users;
using Identity.Infrastructure.Users.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Utils.Context
{
    public class IdentityContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) { 
            builder.ApplyConfiguration(new UserDbConfig());
            base.OnModelCreating(builder);    
        }
    }
}
