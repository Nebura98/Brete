using CQRS.Core.Applications.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;


namespace Brete.Query.Infrastructure.Caching;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        string? cacheValue = await _distributedCache.GetStringAsync(key, cancellationToken);

        if (cacheValue is null) return null;

        T? value = JsonSerializer.Deserialize<T>(cacheValue);

        return value;
    }

    public async Task<T> GetAsync<T>(string key, Func<Task<T>> factory, CancellationToken cancellationToken) where T : class
    {
        T? cachedValue = await GetAsync<T>(key, cancellationToken);

        if (cachedValue is not null) return cachedValue;

        cachedValue = await factory();

        await SetAsync(key, cachedValue, cancellationToken);

        return cachedValue;
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await _distributedCache.RemoveAsync(key, cancellationToken);
    }

    public Task RemoveByPrefixAsync(string byPrefix, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task SetAsync<T>(string key, T Value, CancellationToken cancellationToken = default) where T : class
    {
        string cacheValue = JsonSerializer.Serialize(Value);

        await _distributedCache.SetStringAsync(key, cacheValue, cancellationToken);
    }
}
