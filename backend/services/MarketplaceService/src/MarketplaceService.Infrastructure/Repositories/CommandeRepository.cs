using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using MarketplaceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceService.Infrastructure.Repositories
{
    public class CommandeRepository : ICommandeRepository
    {
        private readonly ApiDbContext apiDbContext;

        public CommandeRepository(ApiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }

        public async Task AddCommandeAsync(Commande commande)
        {
            await apiDbContext.commandes.AddAsync(commande);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task DeleteCommandeAsync(int id)
        {
            var commande = await apiDbContext.commandes.FindAsync(id);
            if (commande != null)
            {
                apiDbContext.commandes.Remove(commande);
                await apiDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Commande>> GetAllCommandesAsync()
        {
            return await apiDbContext.commandes.ToListAsync();
        }

        public async Task<List<Commande>> GetCommandesByCustomerAsync(string CustomerId)
        {
            return await apiDbContext.commandes.Where(x => x.CustomerId == CustomerId).ToListAsync();
        }

        public async Task<Commande> GetCommandeByIdAsync(int id)
        {
            Commande? commande = await apiDbContext.commandes.FindAsync(id);
            if (commande == null)
            {
                throw new KeyNotFoundException("commande not found");
            }
            return commande;
        }

        public async Task UpdateCommandeAsync(Commande commande)
        {
            var existingCommande = await apiDbContext.commandes.FindAsync(commande.CommandeId);
            if (existingCommande != null)
            {
                apiDbContext.Entry(existingCommande).CurrentValues.SetValues(commande);
                await apiDbContext.SaveChangesAsync();
            }
        }

        public async Task<Commande> GetCommandesByPaymentIdAsync(string PaymentId)
        {
            Commande? commande = await apiDbContext.commandes.FirstOrDefaultAsync(x => x.PayementId == PaymentId);
            if (commande == null)
            {
                throw new KeyNotFoundException("commande not found");
            }
            return commande;
        }
    }

}
