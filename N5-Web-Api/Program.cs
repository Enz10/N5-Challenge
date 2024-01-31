using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using N5_Web_Api.Configuration;
using System.Reflection;

try
{
    Console.WriteLine("Starting up");

    var builder = WebApplication.CreateBuilder(args);
    ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

    var app = builder.Build();
    ConfigureMiddlewares(app, builder.Configuration);

    await app.RunAsync();
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex?.ToString(), "Application failed");
}

static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
{
    services.AddMediatRConfiguration();
    services.AddSieve(configuration);
    services.ConfigureDatabases(configuration);
    services.ConfigureMapper();
    services.AddControllers();
}

static void ConfigureMiddlewares(WebApplication app, IConfiguration configuration)
{
    app.UseExceptionHandler(errorPipeline =>
    errorPipeline.UseMiddleware<ExceptionHandlerMiddleware>(configuration));

    app.UseStaticFiles();
    app.UseRouting();

    app.UseResponseCompression();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}

public partial class Program { }