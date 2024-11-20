using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Repositories
{
    public interface ICommandeProductRepository
    {
        // Get all commandeProducts
        Task<List<CommandeProduct>> GetAllCommandeProductsAsync();

        // Get a commandeProduct by ID
        Task<CommandeProduct?> GetCommandeProductByIdAsync(int CommandeId, string ProductId);

        // Add a new commandeProduct
        Task AddCommandeProductAsync(CommandeProduct commandeProduct);

        // Update an existing commandeProduct
        Task UpdateCommandeProductAsync(CommandeProduct commandeProduct);

        // Delete a commandeProduct by ID
        Task DeleteCommandeProductAsync(int CommandeId, string ProductId);
    }
}
