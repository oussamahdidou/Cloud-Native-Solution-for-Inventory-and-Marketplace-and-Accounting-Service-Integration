using MarketplaceService.Application.Dtos.Category;

namespace MarketplaceService.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategorieItem>> GetCategoriesAsync();
    }
}
