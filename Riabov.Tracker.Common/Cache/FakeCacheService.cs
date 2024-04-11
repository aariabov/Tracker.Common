namespace Riabov.Tracker.Common.Cache;

public class FakeCacheService : ICacheService
{
    public Task<T?> GetAsync<T>(string key)
    {
        return Task.FromResult<T?>(default);
    }

    public Task SetAsync(string key, object value, TimeSpan expireTime)
    {
        return Task.CompletedTask;
    }
}