using Identity.Data.Mapping;
using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data.Context
{
    public class IdentityContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(builder);
        }
    }
}
