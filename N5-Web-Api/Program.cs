using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using N5_Web_Api.Configuration;
using System;

try
{
    Console.WriteLine("Starting up");

    var builder = WebApplication.CreateBuilder(args);

    // Configurar Kestrel si es necesario
    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenAnyIP(80); // Escucha en el puerto 5000 dentro del contenedor
    });

    // Agrega servicios al contenedor DI
    ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

    var app = builder.Build();

    // Configurar la aplicaci�n HTTP request pipeline
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
    // Configuraci�n del middleware de manejo de excepciones
    app.UseExceptionHandler(errorPipeline =>
    {
        errorPipeline.Run(async context =>
        {
            context.Response.StatusCode = 500; // Internal Server Error
            context.Response.ContentType = "text/plain";

            var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionFeature != null)
            {
                // Aqu� se registra la excepci�n
                Console.Error.WriteLine($"Excepci�n: {exceptionFeature.Error}");

                // Env�a un mensaje de error gen�rico
                await context.Response.WriteAsync("Ocurri� un error inesperado.");
            }
        });
    });
    app.UseSwagger();

    app.UseSwaggerUI();

    app.UseStaticFiles();
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}

public partial class Program { }
