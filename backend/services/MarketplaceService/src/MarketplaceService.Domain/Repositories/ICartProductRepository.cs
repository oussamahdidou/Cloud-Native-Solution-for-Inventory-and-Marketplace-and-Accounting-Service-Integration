using MarketplaceService.Domain.Entities;

namespace MarketplaceService.Domain.Repositories
{
    public interface ICartProductRepository
    {
        // Get all cartProducts
        Task<List<CartProduct>> GetAllCartProductsAsync();

        // Get a cartProduct by ID
        Task<CartProduct> GetCartProductByIdAsync(int CartId, string ProductId);

        // Add a new cartProduct
        Task AddCartProductAsync(CartProduct cartProduct);

        // Update an existing cartProduct
        Task UpdateCartProductAsync(CartProduct cartProduct);

        // Delete a cartProduct by ID
        Task DeleteCartProductAsync(int CartId, string ProductId);
    }
}
