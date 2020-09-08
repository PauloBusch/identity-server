using Identity.Data._Common.Repositories;
using Identity.Data.Context;
using Identity.Data.Repositories;
using Identity.Domain.Interfaces.Repositories;
using Identity.Domain.Interfaces.Repositories.Users;
using Identity.Domain.Interfaces.Services.Users;
using Identity.Service.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.CrossCutting.Injection
{
    public static class ConfigureInjection
    {
        public static void Database(IServiceCollection serviceCollection)
        {
            var connectionString = "Server=localhost;Port=3306;Database=Identity;Uid=identity;Pwd=123";
            serviceCollection.AddDbContext<IdentityContext>(
                options => options.UseMySql(connectionString)    
            );
        }

        public static void Services(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IAuthService, AuthService>();
        }

        public static void Repositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
