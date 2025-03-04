using MarketplaceService.Domain.Entities;

namespace MarketplaceService.Domain.Repositories
{
    public interface ICartRepository
    {
        // Get all carts
        Task<List<Cart>> GetAllCartsAsync();

        // Get a cart by ID
        Task<Cart> GetCartByIdAsync(int id);
        Task<Cart> GetCartByCustomerAsync(string CustomerId);

        // Add a new cart
        Task AddCartAsync(Cart cart);

        // Update an existing cart
        Task UpdateCartAsync(Cart cart);

        // Delete a cart by ID
        Task DeleteCartAsync(int id);
    }
}
