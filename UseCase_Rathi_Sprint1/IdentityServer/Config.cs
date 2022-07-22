// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[] {
            new ApiResource("Airline","Airline Scope"),
            new ApiResource("Search","Search Scope"),
            new ApiResource("Ticket","Ticket Scope"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[] {
             new Client
                {
                    ClientId="client 1",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"Airline"},
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime=3600
                },
             new Client
                {
                    ClientId="client 2",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"Search"},
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime=3600
                },
             new Client
                {
                    ClientId="client 3",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"Ticket"},
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime=3600
                },
            };
        }
    }
}