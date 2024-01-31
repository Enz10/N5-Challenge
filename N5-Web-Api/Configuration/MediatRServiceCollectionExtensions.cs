using Application;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace N5_Web_Api.Configuration;

public static class MediatRServiceCollectionExtensions
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Program).Assembly);
        services.AddMediatR(typeof(ApplicationConstant).Assembly);
    }
}
