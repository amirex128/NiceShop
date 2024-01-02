using Nest;

namespace NiceShop.Application.Common.Interfaces;

public interface IElasticsearchContext
{
    public IElasticClient ElasticClient { get; set; }
    
}
