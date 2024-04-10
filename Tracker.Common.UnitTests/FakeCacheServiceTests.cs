using Riabov.Tracker.Common.Cache;

namespace Tracker.Common.UnitTests;

public class FakeCacheServiceTests
{
    [Fact]
    public async Task fake_cache()
    {
        var cacheValue = 1;
        var sut = new FakeCacheService();

        var val = await sut.GetAsync<int?>("key");
        Assert.Null(val);

        await sut.SetAsync("key", cacheValue, TimeSpan.FromSeconds(1));
        val = await sut.GetAsync<int?>("key");
        Assert.Null(val);
    }
}