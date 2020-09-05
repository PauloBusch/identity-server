using Identity.Domain.Clients.Services;
using Identity.Domain.Companies.Services;
using Identity.Domain.Users.Services;
using Identity.Domain.Utils.Common;
using Identity.Domain.Utils.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.API
{
    public static class IocMapping
    {
        public static void AddRepositories(IServiceCollection collection)
        {
            //collection.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            //collection.AddScoped<IUserRepository, UserRepository>();
            //collection.AddScoped<ICompanyRepository, CompanyRepository>();
            //collection.AddScoped<IClientRepository, ClientRepository>();
        }
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IService<>), typeof(ServiceBase<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
