using Identity.Domain.Users.Repositories;
using Identity.Domain.Users.Services;
using Identity.Domain.Utils.Interfaces;
using Identity.Infrastructure.Users.AutoMapper;
using Identity.Infrastructure.Users.Repositories;
using Identity.Infrastructure.Utils.Common;
using Identity.Service.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.API
{
    public static class IocMapping
    {
        public static void AddRepositories(IServiceCollection collection)
        {
            collection.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            collection.AddScoped<IUserRepository, UserRepository>();
            //collection.AddScoped<ICompanyRepository, CompanyRepository>();
            //collection.AddScoped<IClientRepository, ClientRepository>();
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ICompanyService, CompanyService>();
            //services.AddScoped<IClientService, ClientService>();
        }

        public static void AddAutoMapper(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(options => {
                options.AddProfile(new UserProfile());
            });
            services.AddSingleton(config.CreateMapper());
        }
    }
}
