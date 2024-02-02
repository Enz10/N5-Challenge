using Microsoft.AspNetCore.Diagnostics;
using N5_Web_Api.Configuration;

try
{
    Console.WriteLine("Starting up");

    var builder = WebApplication.CreateBuilder(args);

    ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

    var app = builder.Build();

    ConfigureMiddlewares(app);

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
    services.ConfigureElasticSearch(configuration);
    services.ConfigureMapper();
    services.AddControllers();
    services.AddSwaggerGen();
}

static void ConfigureMiddlewares(WebApplication app)
{
    app.UseExceptionHandler("/Error");


    app.UseStaticFiles();
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.UseSwagger();

    app.UseSwaggerUI();

}

public partial class Program { }
