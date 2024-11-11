using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using MarketplaceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiDbContext apiDbContext;

        public CategoryRepository(ApiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }
        public async Task AddCategoryAsync(Category category)
        {
            await apiDbContext.categories.AddAsync(category);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await apiDbContext.categories.FindAsync(id);
            if (category != null)
            {
                apiDbContext.categories.Remove(category);
                await apiDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await apiDbContext.categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await apiDbContext.categories.FindAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = await apiDbContext.categories.FindAsync(category.CategoryId);
            if (existingCategory != null)
            {
                apiDbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await apiDbContext.SaveChangesAsync();
            }
        }
    }
}
