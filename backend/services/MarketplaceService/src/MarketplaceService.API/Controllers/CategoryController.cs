using MarketplaceService.Application.Dtos.Category;
using MarketplaceService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            List<CategorieItem> categorieItems = await categoryService.GetCategoriesAsync();
            return Ok(categorieItems);
        }
        
}
}
