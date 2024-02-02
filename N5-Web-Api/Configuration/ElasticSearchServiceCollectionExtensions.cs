using Application.ElasticSearchEntities;
using Elasticsearch.Net;
using Nest;
using System;

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
            var pool = new SingleNodeConnectionPool(new Uri(elasticsearchSettings.Uri));
            var settings = new ConnectionSettings(pool)
                .DefaultIndex(elasticsearchSettings.DefaultIndex);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
