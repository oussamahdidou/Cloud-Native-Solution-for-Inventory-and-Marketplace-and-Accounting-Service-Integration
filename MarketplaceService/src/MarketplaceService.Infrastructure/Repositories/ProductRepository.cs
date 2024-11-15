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
    public class ProductRepository : IProductRepository
    {
        private readonly apiDbContext apiDbContext;

        public ProductRepository(apiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }

        public async Task AddProductAsync(Product product)
        {
            await apiDbContext.products.AddAsync(product);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(string id)
        {
            var product = await apiDbContext.products.FindAsync(id);
            if (product != null)
            {
                apiDbContext.products.Remove(product);
                await apiDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await apiDbContext.products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await apiDbContext.products.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await apiDbContext.products.FindAsync(product.ProductId);
            if (existingProduct != null)
            {
                apiDbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                await apiDbContext.SaveChangesAsync();
            }
        }
    }

}
