using MarketplaceService.Application.Dtos.Category;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Application.Mappers;
using MarketplaceService.Domain.Caching;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;

namespace MarketplaceService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IRedisCachingService redisCachingService;

        public CategoryService(ICategoryRepository categoryRepository, IRedisCachingService redisCachingService)
        {
            this.categoryRepository = categoryRepository;
            this.redisCachingService = redisCachingService;
        }

        public async Task<List<CategorieItem>> GetCategoriesAsync()
        {
            List<Category> categories = await categoryRepository.GetAllCategoriesAsync();
            return categories.Select(x => x.FromCategorieToItem()).ToList();
        }
    }
}
