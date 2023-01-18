using deliverybook.API.Configurations.Mapping;
using deliverybook.Infra.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace deliverybook.API.Configurations
{
    public static class AutomapperConfig
    {
        public static IServiceCollection ResolveAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InfraToDomainMapping),
                                    typeof(DomainToViewModelMapping));
            return services;
        }
    }
}