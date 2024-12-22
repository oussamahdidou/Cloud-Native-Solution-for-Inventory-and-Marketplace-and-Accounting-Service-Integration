using FakeItEasy;
using MarketplaceService.Infrastructure.Caching;
using Microsoft.Extensions.Caching.Distributed;
namespace MarketplaceService.Infrastructure.tests.Caching
{
    public class RedisCachingServiceTests
    {
        private readonly IDistributedCache cache;
        private readonly RedisCachingService redisCachingService;
        public RedisCachingServiceTests()
        {
            cache = A.Fake<IDistributedCache>();
            redisCachingService = new RedisCachingService(cache);
        }
        [Fact]
        public async Task AddItemToCacheAsync_ShouldReturnItem_WhenItemNotNull()
        {

        }
        [Fact]
        public async Task GetElementByKeyAsync_ShouldThrowError_WhenKeyIsNull()
        {

        }
        [Fact]
        public async Task GetElementByKeyAsync_ShouldRetrun_WhenKeyIsNotNull()
        {

        }
    }
}
