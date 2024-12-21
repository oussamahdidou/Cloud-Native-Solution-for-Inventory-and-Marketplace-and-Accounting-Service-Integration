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
    }
}
