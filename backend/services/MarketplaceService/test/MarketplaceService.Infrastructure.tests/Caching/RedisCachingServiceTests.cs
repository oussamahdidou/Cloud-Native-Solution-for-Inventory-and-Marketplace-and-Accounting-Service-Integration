using FakeItEasy;
using FluentAssertions;
using MarketplaceService.Infrastructure.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
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
            //Arrange
            string key = "key";
            object item = new
            {
                name = "name",
                username = "username",
                //other fields 
            };
            var serializedItem = JsonSerializer.Serialize(item);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };
            A.CallTo(() => cache.SetStringAsync(key, serializedItem, options, default))
                .Returns(Task.CompletedTask);


            // Act
            var act = await redisCachingService.AddItemToCacheAsync<object>(key, serializedItem);

            // Assert
            act.Should().BeEquivalentTo(item);
            A.CallTo(() => cache.SetStringAsync(key, serializedItem, options, default))
                    .MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task GetElementByKeyAsync_ShouldThrowError_WhenKeyIsNull()
        {
            //Arrange
            string key = null;

            //Act
            Func<Task> act = async () => await redisCachingService.GetElementByKeyAsync<object>(key);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{nameof(key)}')");

        }
        [Fact]
        public async Task GetElementByKeyAsync_ShouldRetrunItem_WhenKeyIsNotNull()
        {
            // Arrange
            string key = "key";
            string cachedString = JsonSerializer.Serialize(new
            {
                key = key,
                name = "name",
            });

            // Mock the GetStringAsync method by calling the method directly on the fake cache instance
            A.CallTo(() => cache.GetStringAsync(key, default))
                .Returns(Task.FromResult(cachedString));

            // Act
            var result = await redisCachingService.GetElementByKeyAsync<object>(key);

            // Assert
            result.Should().BeEquivalentTo(new
            {
                key = key,
                name = "name",
            });
        }
        [Fact]
        public async Task GetElementByKeyAsync_ShouldThrowError_WhenDeSerialialisationfails()
        {

        }
    }
}
