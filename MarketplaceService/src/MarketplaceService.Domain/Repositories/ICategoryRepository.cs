using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Repositories
{
    public interface ICategoryRepository
    {
        // Get all categories
        Task<List<Category>> GetAllCategoriesAsync();

        // Get a category by ID
        Task<Category> GetCategoryByIdAsync(string id);

        // Add a new category
        Task AddCategoryAsync(Category category);

        // Update an existing category
        Task UpdateCategoryAsync(Category category);

        // Delete a category by ID
        Task DeleteCategoryAsync(string id);
    }
}
