using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Caching
{
    public interface IRedisCachingService
    {
       Task<T> GetElementByKeyAsync<T>(string key);
       Task<T> AddItemToCacheAsync<T>(T item,string key);
       Task<bool> RemoveItemFromCacheAsync(string key);
    }
}
