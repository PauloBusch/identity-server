using Identity.CrossCutting.Injection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Identity.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureInjection.Database(services);
            ConfigureInjection.Services(services);
            ConfigureInjection.Repositories(services);
            services.AddMvcCore()
                .AddJsonOptions(options => { 
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });
            services.AddControllers();
            services.AddSwaggerGen(options => { 
                options.SwaggerDoc("v1", new OpenApiInfo { 
                    Version = "v1",
                    Title = "Identity Server API",
                    Description = "Identity Server",
                    Contact = new OpenApiContact {
                        Name = "Paulo Ricardo Busch",
                        Email = "paulo202015@outlook.com.br",
                        Url = new Uri("https://www.dynsoftware.net")
                    }
                });    
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(options => { 
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity Server .NET CORE");
                options.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
