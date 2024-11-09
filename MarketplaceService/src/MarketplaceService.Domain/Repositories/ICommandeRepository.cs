using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Repositories
{
    public interface ICommandeRepository
    {
        // Get all commandes
        Task<List<Commande>> GetAllCommandesAsync();

        // Get a commande by ID
        Task<Commande> GetCommandeByIdAsync(int id);

        // Add a new commande
        Task AddCommandeAsync(Commande commande);

        // Update an existing commande
        Task UpdateCommandeAsync(Commande commande);

        // Delete a commande by ID
        Task DeleteCommandeAsync(int id);
    }
}
