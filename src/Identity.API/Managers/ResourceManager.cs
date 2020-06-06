
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer.Managers  
{
    internal static class ResourceManager {
        public static IEnumerable<ApiResource> Apis => 
            new List<ApiResource> {
                new ApiResource {
                    Name = "app.api1",
                    DisplayName = "API 1",
                    ApiSecrets = { new Secret("secret".Sha256()) },
                    Scopes = new List<Scope> {
                        new Scope("app.api1.read"),
                        new Scope("app.api1.write"),
                        new Scope("app.api1.full")
                    }
                },
                new ApiResource {
                    Name = "app.api2",
                    DisplayName = "API 2"
                }
            };
    }
}