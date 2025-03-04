namespace MarketplaceService.Domain.Caching
{
    public interface IRedisCachingService
    {
        Task<T> GetElementByKeyAsync<T>(string key);
        Task<T> AddItemToCacheAsync<T>(T item, string key);
        Task<bool> RemoveItemFromCacheAsync(string key);
    }
}
