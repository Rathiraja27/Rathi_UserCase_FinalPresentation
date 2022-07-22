using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Common
{
    public static class AppExtensions
    {
        /// <summary>Adds the consul configuration.</summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Consul Service Details </returns>
        public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulconfig =>
            {
                var address = configuration["Consul:ConsulAddress"];
                consulconfig.Address = new Uri(address);
            }));

            return services;
        }


        /// <summary>Uses the consul.</summary>
        /// <param name="app">The application.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Application Builder</returns>
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtensions");
            var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
            var registration = new AgentServiceRegistration()
            {
                ID = configuration["Consul:ServiceId"],
                Name = configuration["Consul:ServiceName"],
                Address = configuration["Consul:ServiceHost"],
                Port = int.Parse(configuration["Consul:ServicePort"])
            };
            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);
            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Unregistering from Consul");
            });
            return app;
        }
    }
}
