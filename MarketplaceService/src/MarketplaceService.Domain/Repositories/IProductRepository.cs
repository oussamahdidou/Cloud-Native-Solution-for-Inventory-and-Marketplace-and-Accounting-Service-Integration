﻿using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Repositories
{
    public interface IProductRepository
    {
        // Get all products
        Task<List<Product>> GetAllProductsAsync(ProductQuery productQuery);

        // Get a product by ID
        Task<Product> GetProductByIdAsync(int id);

        // Add a new product
        Task AddProductAsync(Product product);

        // Update an existing product
        Task UpdateProductAsync(Product product);

        // Delete a product by ID
        Task DeleteProductAsync(int id);
    }
}
