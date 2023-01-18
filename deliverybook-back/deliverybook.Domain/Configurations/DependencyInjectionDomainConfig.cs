using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Notificacoes;
using deliverybook.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace deliverybook.Domain.Configurations
{
    public static class DependencyInjectionDomainConfig
    {
        public static IServiceCollection ResolveDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<IItBookNewServices, ItBookNewServices>();
            services.AddScoped<IItBookBooksServices, ItBookBooksServices>();
            services.AddScoped<IItBookSearchServices, ItBookSearchServices>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ISpotifySearchService, SpotifySearchService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ILocalServices, LocalServices>();
            services.AddScoped<IRentableServices, RentableServices>();
            services.AddScoped<IReservaServices, ReservaServices>();
            
            return services;
        }
    }
}