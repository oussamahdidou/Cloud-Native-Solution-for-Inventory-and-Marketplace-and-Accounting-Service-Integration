using FakeItEasy;
using FluentAssertions;
using MarketplaceService.API.Controllers;
using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
namespace MarketplaceService.API.tests.Controllers
{

    public class ProductControllerTests
    {
        private readonly IProductService productService;
        private readonly ProductController productController;
        public ProductControllerTests()
        {
            productService = A.Fake<IProductService>();
            productController = new ProductController(productService);
        }
        [Fact]
        public async Task ProductController_GetProducts_ReturnOkAsync()
        {
            //Arrange
            var fakeQuery = A.Fake<ProductQuery>();
            var fakeProducts = A.Fake<List<ProductItem>>();
            A.CallTo(() => productService.GetProductItems(fakeQuery)).Returns(Task.FromResult(fakeProducts));
            // Act
            var result = await productController.GetProducts(fakeQuery);
            // Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(fakeProducts);
            // Verify the method was called with the correct query
            A.CallTo(() => productService.GetProductItems(fakeQuery)).MustHaveHappenedOnceExactly();
        }
        [Theory]
        [InlineData("valid-id-123", true)]  // Valid ID, should return OK
        [InlineData("invalid-id-456", false)]
        public async Task GetProductDetail_ShouldReturnExpectedResult(string productId, bool shouldFindProduct)
        {
            // Arrange
            if (shouldFindProduct)
            {
                var fakeProductDetail = new ProductDetail
                {
                    ProductId = productId,
                    Name = "Product1",
                    Description = "Description of Product1",
                    Price = 50.0,
                    CategoryId = "categoryId",
                    CategoryName = "categoryname",
                    CategoryThumbnail = "categoryThumbnail",
                    MarqueIcon = "MarqueIcon",
                    MarqueName = "marque Name",
                    Quantity = 123,
                    Thumbnail = "thumbnail"
                };

                A.CallTo(() => productService.GetProductDetail(productId))
                    .Returns(Task.FromResult(fakeProductDetail));
            }
            else
            {
                A.CallTo(() => productService.GetProductDetail(productId))
                    .Throws(new KeyNotFoundException("product not found"));
            }

            // Act
            var result = await productController.GetProductDetail(productId);

            // Assert
            if (shouldFindProduct)
            {
                result.Should().BeOfType<OkObjectResult>()
                    .Which.Value.Should().BeEquivalentTo(new
                    {
                        ProductId = productId,
                        Name = "Product1",
                        Description = "Description of Product1",
                        Price = 50.0,
                        CategoryId = "categoryId",
                        CategoryName = "categoryname",
                        CategoryThumbnail = "categoryThumbnail",
                        MarqueIcon = "MarqueIcon",
                        MarqueName = "marque Name",
                        Quantity = 123,
                        Thumbnail = "thumbnail"
                    });
            }
            else
            {
                result.Should().BeOfType<NotFoundObjectResult>()
                    .Which.Value.Should().Be("product not found");
            }

            // Verify the method was called once
            A.CallTo(() => productService.GetProductDetail(productId)).MustHaveHappenedOnceExactly();
        }
    }
}
