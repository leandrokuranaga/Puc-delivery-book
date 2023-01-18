using deliverybook.Domain.Configurations;
using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model;
using deliverybook.Domain.Model.Spotify.Auth;
using deliverybook.Infra.Configurations;
using deliverybook.Infra.ExternalServices;
using deliverybook.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace deliverybook.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var apiUrls = configuration.GetSection("ServicosUrl").Get<ServicosUrl>();
            services.AddSingleton(apiUrls);

            var credentials = configuration.GetSection("Credentials").Get<ClientCredentials>();
            services.AddSingleton(credentials);

            services.AddHttpClient<IExternalService, ExternalService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.ResolveDomainDependencies();
            services.ResolveInfraDependencies(configuration);
            return services;
        }
    }
}