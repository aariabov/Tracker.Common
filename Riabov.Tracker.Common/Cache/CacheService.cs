using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Riabov.Tracker.Common.Cache;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _cache.GetStringAsync(key);
        if (value is not null)
        {
            var result = JsonSerializer.Deserialize<T>(value);
            return result;
        }

        return default;
    }

    public Task SetAsync(string key, object value, TimeSpan expireTime)
    {
        var valueStr = JsonSerializer.Serialize(value);
        return _cache.SetStringAsync(key, valueStr, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expireTime
        });
    }
}