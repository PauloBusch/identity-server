using FluentValidation.AspNetCore;
using Identity.Domain;
using Identity.Domain.Utils.Enums;
using Identity.Domain.Utils.Responses;
using Identity.Infrastructure.Utils.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Identity.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options => { 
                options.UseMySql(Configuration.GetConnectionString("Identity"));     
            });

            IocMapping.AddRepositories(services);
            IocMapping.AddServices(services);
            IocMapping.AddAutoMapper(services);

            services.AddControllers();
            services.AddMvcCore()
                .ConfigureApiBehaviorOptions(
                    options => options.InvalidModelStateResponseFactory = ctx => { 
                        var errors = ctx.ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage);    
                        var result = new Response(EStatus.Invalid, errors);
                        return new BadRequestObjectResult(result);
                    }
                )
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining(typeof(IdentityStartup)))
                .AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
