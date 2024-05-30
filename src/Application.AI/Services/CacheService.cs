using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using NiceShop.Application.AI.Common.Interfaces;

namespace NiceShop.Application.AI.Services;

public class CacheService(IDistributedCache cache) : ICacheService
{
    public void Add(string key, object value)
    {
        cache.SetString(key, JsonSerializer.Serialize(value));
    }

    public void AddInterval(string key, object value, int timeSpan)
    {
        cache.SetString(key, JsonSerializer.Serialize(value),
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(timeSpan) });
    }
}
