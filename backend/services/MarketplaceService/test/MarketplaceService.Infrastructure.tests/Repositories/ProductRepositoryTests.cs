using FluentAssertions;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Queries;
using MarketplaceService.Infrastructure.Data;
using MarketplaceService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceService.Infrastructure.tests.Repositories
{
    public class ProductRepositoryTests
    {
        private readonly ApiDbContext apiDbContext;
        private readonly ProductRepository productRepository;
        public ProductRepositoryTests()
        {
            this.apiDbContext = GetDbContextAsync().Result;
            this.productRepository = new ProductRepository(this.apiDbContext);
        }
        public async Task<ApiDbContext> GetDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                           .Options;
            var apiDbContext = new ApiDbContext(options);
            apiDbContext.Database.EnsureCreated();
            if (await apiDbContext.products.CountAsync() <= 0)
            {

                apiDbContext.products.AddRange(
                     new Product
                     {
                         ProductId = "P4", // Unique identifier for the product
                         Name = "Washing Machine", // Product name
                         Description = "Front-load washing machine", // Product description
                         Price = 499.99, // Product price
                         Quantity = 20, // Available quantity
                         Thumbnail = "washing_machine.png", // Product thumbnail (e.g., image path)
                         MarqueName = "BrandA", // Brand name
                         MarqueIcon = "brandA.png", // Brand icon

                         // Create and associate a new Category with the product
                         Category = new Category
                         {
                             CategoryId = "C4", // Unique identifier for the category
                             Name = "Home Appliances", // Category name
                             Thumbnail = "home_appliances.png", // Category thumbnail (e.g., image path)
                         }
                     },
                    new Product
                    {
                        ProductId = "P5", // Unique identifier for the product
                        Name = "Refrigerator", // Product name
                        Description = "Energy-efficient refrigerator", // Product description
                        Price = 799.99, // Product price
                        Quantity = 15, // Available quantity
                        Thumbnail = "refrigerator.png", // Product thumbnail (e.g., image path)
                        MarqueName = "BrandB", // Brand name
                        MarqueIcon = "brandB.png", // Brand icon

                        // Create and associate a new Category with the product
                        Category = new Category
                        {
                            CategoryId = "C5", // Unique identifier for the category
                            Name = "Kitchen Appliances", // Category name
                            Thumbnail = "kitchen_appliances.png", // Category thumbnail (e.g., image path)
                        }
                    },
                    new Product
                    {
                        ProductId = "P6", // Unique identifier for the product
                        Name = "Microwave Oven", // Product name
                        Description = "Compact microwave oven", // Product description
                        Price = 149.99, // Product price
                        Quantity = 40, // Available quantity
                        Thumbnail = "microwave.png", // Product thumbnail (e.g., image path)
                        MarqueName = "BrandC", // Brand name
                        MarqueIcon = "brandC.png", // Brand icon

                        // Create and associate a new Category with the product
                        Category = new Category
                        {
                            CategoryId = "C6", // Unique identifier for the category
                            Name = "Home Appliances", // Category name
                            Thumbnail = "home_appliances_2.png", // Category thumbnail (e.g., image path)
                        }
                    });
                await apiDbContext.SaveChangesAsync();

            }
            return apiDbContext;
        }
        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var productQuery = new ProductQuery();

            // Act
            var result = await productRepository.GetAllProductsAsync(productQuery);

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(p => p.Name == "Product1");
            result.Should().Contain(p => p.Name == "Product2");
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnCorrectProduct()
        {
            // Act
            var result = await productRepository.GetProductByIdAsync("P5");

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Product1");
        }

        [Fact]
        public async Task AddProductAsync_ShouldAddProductToDatabase()
        {
            // Arrange
            var newProduct = new Product { ProductId = "3", Name = "Product3" };

            // Act
            await productRepository.AddProductAsync(newProduct);
            var result = await productRepository.GetAllProductsAsync(new ProductQuery());

            // Assert
            result.Should().HaveCount(3);
            result.Should().Contain(p => p.Name == "Product3");
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldUpdateProductInDatabase()
        {
            // Arrange
            var existingProduct = await productRepository.GetProductByIdAsync("P5");
            existingProduct.Name = "UpdatedProduct";

            // Act
            await productRepository.UpdateProductAsync(existingProduct);
            var result = await productRepository.GetProductByIdAsync("P5");

            // Assert
            result.Name.Should().Be("UpdatedProduct");
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldRemoveProductFromDatabase()
        {
            // Act
            await productRepository.DeleteProductAsync("P5");
            var result = await productRepository.GetAllProductsAsync(new ProductQuery());

            // Assert
            result.Should().HaveCount(1);
            result.Should().NotContain(p => p.ProductId == "1");
        }
    }
}
