using Elasticsearch.Net;
using Nest;
using static N5_Web_Api.Configuration.DatabasesServiceCollectionExtensions;

namespace N5_Web_Api.Configuration
{
    public static class ElasticSearchServiceCollectionExtensions
    {
        public class ElasticSearchSettings
        {
            public string Uri { get; set; }
            public string DefaultIndex { get; set; }
        }

        public static void ConfigureElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var elasticsearchSettings = configuration.GetSection(nameof(ElasticSearchSettings)).Get<ElasticSearchSettings>();
            var settings = new ConnectionSettings(new Uri(elasticsearchSettings.Uri))
                .DefaultIndex(elasticsearchSettings.DefaultIndex);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
