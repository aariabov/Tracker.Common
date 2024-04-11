namespace Riabov.Tracker.Common.Cache;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key);
    Task SetAsync(string key, object value, TimeSpan expireTime);
}