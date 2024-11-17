using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductQuery productQuery)
        {
            List<ProductItem> productItems = await productService.GetProductItems(productQuery);
        return Ok(productItems);
        }
        [HttpGet("ProductDetail/{Id}")]
        public async Task<IActionResult> GetProductDetail([FromRoute] string Id)
        {
            ProductDetail productDetail =await productService.GetProductDetail(Id);
            return Ok(productDetail);   
        }
    }
}
