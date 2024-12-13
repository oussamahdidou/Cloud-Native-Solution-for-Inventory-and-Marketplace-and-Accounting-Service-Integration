using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Caching
{
    public interface IRedisCachingService<T>
    {
       Task<T> GetElementByKeyAsync(string key);
       Task<T> AddItemToCacheAsync(T item,string key);
       Task<bool> RemoveItemFromCacheAsync(string key);
    }
}
