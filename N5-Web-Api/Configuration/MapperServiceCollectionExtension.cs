using N5_Web_Api.Controllers;
using Mapster;
using MapsterMapper;

namespace N5_Web_Api.Configuration;

public static class MapperServiceCollectionExtension
{
    public static void ConfigureMapper(this IServiceCollection services)
    {
        TypeAdapterConfig config = new TypeAdapterConfig();
        V1DtoMapperRegistry registry = new V1DtoMapperRegistry();
        config.Apply(registry);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }
}
