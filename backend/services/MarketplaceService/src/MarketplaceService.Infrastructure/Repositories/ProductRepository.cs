using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Queries;
using MarketplaceService.Domain.Repositories;
using MarketplaceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace MarketplaceService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext apiDbContext;

        public ProductRepository(ApiDbContext apiDbContext)
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
            else
            {
                throw new KeyNotFoundException("product not found");
            }
        }

        public async Task<List<Product>> GetAllProductsAsync(ProductQuery productQuery)
        {
            var products = apiDbContext.products.AsQueryable();

            // Apply category filter
            if (!string.IsNullOrEmpty(productQuery.CategoryId))
            {
                products = products.Where(p => p.CategoryId == productQuery.CategoryId);
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

        public async Task<Product> GetProductByIdAsync(string id)
        {
            Product? product = await apiDbContext.products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductId == id);
            if (product != null)
            {
                return product;
            }
            throw new KeyNotFoundException("product not found");
        }

        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await apiDbContext.products.FindAsync(product.ProductId);
            if (existingProduct != null)
            {
                apiDbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                await apiDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("product not found");
            }
        }
    }

}
