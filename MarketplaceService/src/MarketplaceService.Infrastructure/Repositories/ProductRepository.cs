using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Queries;
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

        public async Task DeleteProductAsync(int id)
        {
            var product = await apiDbContext.products.FindAsync(id);
            if (product != null)
            {
                apiDbContext.products.Remove(product);
                await apiDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProductsAsync(ProductQuery productQuery)
        {
            var products = apiDbContext.products.AsQueryable();

            // Apply category filter
            if (productQuery.CategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == productQuery.CategoryId.Value);
            }

            // Apply marque filter
            if (!string.IsNullOrEmpty(productQuery.Marque))
            {
                products = products.Where(p => p.MarqueName.Contains(productQuery.Marque));
            }

            // Apply text search filter
            if (!string.IsNullOrEmpty(productQuery.TextQuery))
            {
                products = products.Where(p => p.Name.Contains(productQuery.TextQuery) || p.Description.Contains(productQuery.TextQuery));
            }

            // Apply sorting based on user preference
            if (productQuery.SortByPrice)
            {
                products = productQuery.Descending ? products.OrderByDescending(p => p.Price) : products.OrderBy(p => p.Price);
            }
            else if (productQuery.SortByQuantity)
            {
                products = productQuery.Descending ? products.OrderByDescending(p => p.Quantity) : products.OrderBy(p => p.Quantity);
            }

            return await products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product? product = await apiDbContext.products.Include(x=>x.Category).FirstOrDefaultAsync(x=>x.ProductId==id);
            if (product!=null)
            {
                return product;
            }
            throw new Exception("product not found");
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
