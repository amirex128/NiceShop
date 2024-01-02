using Nest;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;

namespace NiceShop.Infrastructure.Elasticsearch;

public class ElasticsearchContext : IElasticsearchContext
{
    public IElasticClient ElasticClient { get; set; }

    public ElasticsearchContext(IElasticClient elasticClient)
    {
        ElasticClient = elasticClient;

        if (!ElasticClient.Indices.Exists("products").Exists)
        {
            ElasticClient.Indices.Create("products", index => index
                .Map<Product>(map => map
                    .AutoMap()
                    .Properties(props => props
                        .Text(text => text
                            .Name(p => p.Name)
                            .Analyzer("autocomplete")
                            .SearchAnalyzer("autocomplete")
                        )
                    )
                )
            );
        }
    }
}
