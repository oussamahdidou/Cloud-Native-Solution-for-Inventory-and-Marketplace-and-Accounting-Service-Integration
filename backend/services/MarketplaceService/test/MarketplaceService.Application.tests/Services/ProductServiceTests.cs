using FakeItEasy;
using FluentAssertions;
using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Application.Mappers;
using MarketplaceService.Application.Services;
using MarketplaceService.Domain.Caching;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Queries;
using MarketplaceService.Domain.Repositories;

namespace MarketplaceService.Application.tests.Services
{
    public class ProductServiceTests
    {
        private readonly IProductRepository productRepository;
        private readonly IRedisCachingService redisCachingService;
        private readonly ProductService productService;

        public ProductServiceTests()
        {
            productRepository = A.Fake<IProductRepository>();
            redisCachingService = A.Fake<IRedisCachingService>();
            productService = new ProductService(productRepository, redisCachingService);
        }

        [Fact]
        public async Task GetProductDetail_ShouldReturnProductFromCache_WhenProductExistsInCache()
        {
            // Arrange
            string productId = "123";
            var cachedProduct = new ProductDetail { ProductId = productId, Name = "Cached Product" };

            A.CallTo(() => redisCachingService.GetElementByKeyAsync<ProductDetail>(productId))
                .Returns(Task.FromResult(cachedProduct));

            // Act
            var result = await productService.GetProductDetail(productId);

            // Assert
            result.Should().BeEquivalentTo(cachedProduct);
            A.CallTo(() => productRepository.GetProductByIdAsync(A<string>._))
                .MustNotHaveHappened();
        }

        [Fact]
        public async Task GetProductDetail_ShouldFetchFromRepositoryAndCache_WhenProductNotInCache()
        {
            // Arrange
            string productId = "123";
            var product = new Product
            {
                ProductId = productId,
                Name = "Repository Product",
                MarqueName = "Test Marque",
                MarqueIcon = "marque-icon.png",
                Description = "Test Description",
                Price = 99.99,
                Quantity = 10,
                Thumbnail = "thumbnail.jpg",
                CategoryId = "cat-1",
                Category = new Category
                {
                    CategoryId = "cat-1",
                    Name = "Test Category",
                    Thumbnail = "category-thumb.jpg"
                },
            };

            var expectedProductDetail = product.FromProductToDetail();

            A.CallTo(() => redisCachingService.GetElementByKeyAsync<ProductDetail>(productId))
                .Returns(Task.FromResult<ProductDetail?>(null));

            A.CallTo(() => productRepository.GetProductByIdAsync(productId))
                .Returns(Task.FromResult(product));

            A.CallTo(() => redisCachingService.AddItemToCacheAsync(A<ProductDetail>._, productId))
                .ReturnsLazily((ProductDetail detail, string id) => Task.FromResult(detail));

            // Act
            var result = await productService.GetProductDetail(productId);

            // Assert
            result.Should().BeEquivalentTo(expectedProductDetail);
            A.CallTo(() => redisCachingService.AddItemToCacheAsync(A<ProductDetail>._, productId))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task GetProductDetail_ShouldThrowKeyNotFoundException_WhenProductNotFound()
        {
            // Arrange
            string productId = "123";

            A.CallTo(() => redisCachingService.GetElementByKeyAsync<ProductDetail>(productId))
                .Returns(Task.FromResult<ProductDetail>(null));
            A.CallTo(() => productRepository.GetProductByIdAsync(productId))
                .Returns(Task.FromResult<Product>(null));

            // Act
            Func<Task> act = async () => await productService.GetProductDetail(productId);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage("product not found");
        }

        [Fact]
        public async Task GetProductItems_ShouldReturnMappedProductItems_WhenProductsExist()
        {
            // Arrange
            var productQuery = new ProductQuery { CategoryId = "Electronics" };
            var products = new List<Product>
            {
                new Product { ProductId = "1", Name = "Product 1" },
                new Product { ProductId = "2", Name = "Product 2" }
            };

            A.CallTo(() => productRepository.GetAllProductsAsync(productQuery))
                .Returns(Task.FromResult(products));

            // Act
            var result = await productService.GetProductItems(productQuery);

            // Assert
            result.Should().HaveCount(2);
            result.Select(x => x.ProductId).Should().BeEquivalentTo(new[] { "1", "2" });
        }

        [Fact]
        public async Task GetProductItems_ShouldReturnEmptyList_WhenNoProductsExist()
        {
            // Arrange
            var productQuery = new ProductQuery { CategoryId = "Electronics" };

            A.CallTo(() => productRepository.GetAllProductsAsync(productQuery))
                .Returns(Task.FromResult(new List<Product>()));

            // Act
            var result = await productService.GetProductItems(productQuery);

            // Assert
            result.Should().BeEmpty();
        }
    }
}