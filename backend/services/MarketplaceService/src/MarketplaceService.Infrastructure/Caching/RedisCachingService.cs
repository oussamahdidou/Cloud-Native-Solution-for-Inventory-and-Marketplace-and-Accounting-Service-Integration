using MarketplaceService.Domain.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
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
                AbsoluteExpirationRelativeToNow =  TimeSpan.FromMinutes(5) 
            };

            await _cache.SetStringAsync(key, serializedItem, options);
            return item;
        }

        public async Task<T> GetElementByKeyAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            var cachedItem = await _cache.GetStringAsync(key);
            if (cachedItem == null) return default; 

            return JsonSerializer.Deserialize<T>(cachedItem);
        }

        public async Task<bool> RemoveItemFromCacheAsync(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            await _cache.RemoveAsync(key);
            return true;
        }

    }
}
