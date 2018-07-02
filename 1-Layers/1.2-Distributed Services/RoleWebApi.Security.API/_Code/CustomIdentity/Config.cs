namespace RoleWebApi.Security.API._Code.CustomIdentity
{
    using IdentityServer4;
    using IdentityServer4.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;

    public static class Config
    {
        private static IConfiguration _configuration;

        public static void Init(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>() {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("apiInformation")
                {
                    ApiSecrets =
                    {
                        new Secret("apiInformationS3cret".Sha256())
                    },
                    Scopes =
                    {
                        new Scope
                        {
                            Name = "apiInformationScope",
                            DisplayName = "Scope for the apiInformation ApiResource"
                        }
                    },
                    UserClaims = { "name", "role", "admin", "user", "apiInformation" }
                }
            };
        }


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    
                    // Client secrets
                    ClientSecrets =
                    {
                        new Secret("cli3ntSecret".Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "apiInformation"
                    }
                },
                new Client
                {
                    ClientId = "resourceownerclient",
                   // AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AlwaysIncludeUserClaimsInIdToken = true,
                   //AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    //AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 3500,
                    IdentityTokenLifetime = 3500,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    SlidingRefreshTokenLifetime = 30,
                    AllowOfflineAccess = true,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AlwaysSendClientClaims = true,
                    Enabled = true,
                    ClientSecrets =  new List<Secret> { new Secret("SecurityEv3nts".Sha256()) },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "apiInformation"
                    }
                }
            };
        }
    }
}
