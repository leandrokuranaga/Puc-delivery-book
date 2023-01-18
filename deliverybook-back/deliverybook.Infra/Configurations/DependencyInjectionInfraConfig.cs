using deliverybook.Domain.Interfaces;
using deliverybook.Infra.ExternalServices;
using deliverybook.Infra.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace deliverybook.Infra.Configurations
{
    public static class DependencyInjectionInfraConfig
    {
        public static IServiceCollection ResolveInfraDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IItBookBooksExternalService, ItBookBooksExternalService>();
            services.AddScoped<IItBookNewExternalService, ItBookNewExternalService>();
            services.AddScoped<IItBookSearchExternalService, ItBookSearchExternalService>();
            services.AddScoped<ISpotifySearchExternalService, SpotifySearchExternalService>();

            services.AddScoped<ILocalRepository, LocalRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IAluguelRepository, AluguelRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            
            return services;
        }
    }
}