using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Riabov.Tracker.Common.Cache;

namespace Tracker.Common.UnitTests;

public class CacheServiceTests
{
    [Fact]
    public async Task cache_int_success()
    {
        var cacheValue = 1;
        var options = Options.Create(new MemoryDistributedCacheOptions());
        var cache = new MemoryDistributedCache(options);
        var sut = new CacheService(cache);

        var val = await sut.GetAsync<int?>("key");
        Assert.Null(val);

        await sut.SetAsync("key", cacheValue, TimeSpan.FromSeconds(1));
        val = await sut.GetAsync<int?>("key");
        Assert.Equal(cacheValue, val);
    }

    [Fact]
    public async Task cache_string_success()
    {
        var cacheValue = "test";
        var options = Options.Create(new MemoryDistributedCacheOptions());
        var cache = new MemoryDistributedCache(options);
        var sut = new CacheService(cache);

        var val = await sut.GetAsync<string>("key");
        Assert.Null(val);

        await sut.SetAsync("key", cacheValue, TimeSpan.FromSeconds(1));
        val = await sut.GetAsync<string>("key");
        Assert.Equal(cacheValue, val);
    }

    [Fact]
    public async Task cache_object_success()
    {
        var cacheValue = new TestObject
        {
            Id = 1,
            Name = "test",
            Date = DateTime.Now
        };
        var options = Options.Create(new MemoryDistributedCacheOptions());
        var cache = new MemoryDistributedCache(options);
        var sut = new CacheService(cache);

        var val = await sut.GetAsync<TestObject>("key");
        Assert.Null(val);

        await sut.SetAsync("key", cacheValue, TimeSpan.FromSeconds(1));
        val = await sut.GetAsync<TestObject>("key");
        Assert.Equivalent(cacheValue, val );
    }

    [Fact]
    public async Task cache_array_success()
    {
        var cacheValue = new TestObject[]
        {
            new TestObject { Id = 1, Name = "test", Date = DateTime.Now },
            new TestObject { Id = 2, Name = "test2", Date = DateTime.Now }
        };
        var options = Options.Create(new MemoryDistributedCacheOptions());
        var cache = new MemoryDistributedCache(options);
        var sut = new CacheService(cache);

        var val = await sut.GetAsync<TestObject[]>("key");
        Assert.Null(val);

        await sut.SetAsync("key", cacheValue, TimeSpan.FromSeconds(1));
        val = await sut.GetAsync<TestObject[]>("key");
        Assert.Equivalent(cacheValue, val );
    }

    private class TestObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
    }
}