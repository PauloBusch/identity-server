using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            // Utilizado para geração das migrações
            var connectionString = "Server=localhost;Port=3306;Database=Identity;Uid=root;Pwd=123456";
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
            optionsBuilder.UseMySql(connectionString);
            return new IdentityContext(optionsBuilder.Options);
        }
    }
}
