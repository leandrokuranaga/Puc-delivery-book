using AutoMapper;
using deliverybook.API.Configurations.Mapping;
using deliverybook.Infra.Mapping;

namespace deliverybook.UnitTests.Comum
{
    public static class AutoMapperCreatorTests
    {
        public static IMapper CriarMapeamentos()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfraToDomainMapping>();
                cfg.AddProfile<DomainToViewModelMapping>();
            });
            return configuration.CreateMapper();
        }
    }
}