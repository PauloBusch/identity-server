using Identity.CrossCutting.Injection;
using Identity.Domain._Common.Enums;
using Identity.Domain._Common.Results;
using Identity.Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

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

            var tokenConfig = Configuration.GetSection("TokenConfig").Get<TokenConfig>();
            var signingConfig = new SigningConfig(tokenConfig);

            services.AddSingleton(tokenConfig);
            services.AddSingleton(signingConfig);

            services
                .AddAuthentication(options => { 
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options => {
                    var validation = options.TokenValidationParameters;
                    validation.IssuerSigningKey = signingConfig.Key;
                    validation.ValidAudience = tokenConfig.Audience;
                    validation.ValidIssuer = tokenConfig.Issuer;
                    validation.ValidateIssuerSigningKey = true;
                    validation.ValidateLifetime = true;
                    validation.ClockSkew = TimeSpan.Zero;
                });

            services.AddAuthorization(options => {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddMvcCore()
                .AddJsonOptions(options => { 
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .ConfigureApiBehaviorOptions(
                    options => options.InvalidModelStateResponseFactory = ctx => {
                        var errors = ctx.ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage);
                        var result = new Result(EStatus.Invalid, errors);
                        return new BadRequestObjectResult(result);
                    }
                );
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
