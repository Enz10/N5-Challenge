using Sieve.Models;
using Sieve.Services;

namespace N5_Web_Api.Configuration;

public static class SieveServiceCollectionExtensions
{
    public static void AddSieve(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
        services.Configure<SieveOptions>(configuration.GetSection("Sieve"));
    }
}
