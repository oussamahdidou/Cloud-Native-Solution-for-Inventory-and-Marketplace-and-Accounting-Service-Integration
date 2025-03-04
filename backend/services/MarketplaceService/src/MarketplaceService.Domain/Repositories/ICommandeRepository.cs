using MarketplaceService.Domain.Entities;

namespace MarketplaceService.Domain.Repositories
{
    public interface ICommandeRepository
    {
        // Get all commandes
        Task<List<Commande>> GetAllCommandesAsync();

        // Get a commande by ID
        Task<Commande> GetCommandeByIdAsync(int id);
        Task<Commande> GetCommandesByPaymentIdAsync(string PaymentId);
        Task<List<Commande>> GetCommandesByCustomerAsync(string CustomerId);
        // Add a new commande
        Task AddCommandeAsync(Commande commande);

        // Update an existing commande
        Task UpdateCommandeAsync(Commande commande);

        // Delete a commande by ID
        Task DeleteCommandeAsync(int id);
    }
}
