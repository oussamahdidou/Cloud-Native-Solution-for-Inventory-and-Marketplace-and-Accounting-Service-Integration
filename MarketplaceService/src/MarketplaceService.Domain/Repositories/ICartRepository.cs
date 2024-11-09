using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Repositories
{
    public interface ICartRepository
    {
        // Get all carts
        Task<List<Cart>> GetAllCartsAsync();

        // Get a cart by ID
        Task<Cart> GetCartByIdAsync(int id);

        // Add a new cart
        Task AddCartAsync(Cart cart);

        // Update an existing cart
        Task UpdateCartAsync(Cart cart);

        // Delete a cart by ID
        Task DeleteCartAsync(int id);
    }
}
