using Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Users.DbConfig
{
    public class UserDbConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.PasswordHash)
                .HasMaxLength(80)
                .IsRequired();

            builder.HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}
