
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer.Managers  {
    internal static class ClientManager {
        public static IEnumerable<Client> Clients => 
            new List<Client> {
                new Client {
                    ClientName = "Client API1",
                    ClientId = "sodifkj",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = new [] { "app.api1.read" }
                },
                new Client {
                    ClientName = "Client API2",
                    ClientId = "oihlksfy",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = new [] { "app.api2" } 
                }
            };
    }
}