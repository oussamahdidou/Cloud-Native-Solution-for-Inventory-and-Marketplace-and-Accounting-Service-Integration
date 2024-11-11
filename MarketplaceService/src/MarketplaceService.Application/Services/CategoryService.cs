using MarketplaceService.Application.Dtos.Category;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Application.Mappers;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<CategorieItem>> GetCategoriesAsync()
        {
           List<Category> categories = await categoryRepository.GetAllCategoriesAsync();
            return categories.Select(x=>x.FromCategorieToItem()).ToList();
        }
    }
}
