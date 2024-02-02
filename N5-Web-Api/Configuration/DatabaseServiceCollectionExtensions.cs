using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace N5_Web_Api.Configuration
{
    public static class DatabasesServiceCollectionExtensions
    {
        public class DatabaseSettings
        {
            public string SqlServer { get; set; }
            public string DatabaseName { get; set; }
            public string DbUser { get; set; }
            public string DbPassword { get; set; }
        }

        public static void ConfigureDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            DatabaseSettings databaseSettings = configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();

            string connectionString = $"Server={databaseSettings.SqlServer};Database={databaseSettings.DatabaseName};User Id={databaseSettings.DbUser};Password={databaseSettings.DbPassword};MultipleActiveResultSets=True;";

            services.AddDbContextPool<PermissionContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
