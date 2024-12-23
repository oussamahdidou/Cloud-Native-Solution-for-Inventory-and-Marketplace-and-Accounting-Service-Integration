using MarketplaceService.Domain.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
namespace MarketplaceService.Infrastructure.Caching
{
    public class RedisCachingService : IRedisCachingService
    {
        private readonly IDistributedCache _cache;

        public RedisCachingService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> AddItemToCacheAsync<T>(T item, string key)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var serializedItem = JsonSerializer.Serialize(item);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            await _cache.SetStringAsync(key, serializedItem, options);
            return item;
        }

        public async Task<T> GetElementByKeyAsync<T>(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

                var cachedItem = await _cache.GetStringAsync(key);
                if (cachedItem == null) throw new KeyNotFoundException(key);

                return JsonSerializer.Deserialize<T>(cachedItem);
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public async Task<bool> RemoveItemFromCacheAsync(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            await _cache.RemoveAsync(key);
            return true;
        }

    }
}
