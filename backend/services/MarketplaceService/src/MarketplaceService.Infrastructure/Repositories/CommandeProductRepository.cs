using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using MarketplaceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceService.Infrastructure.Repositories
{
    public class CommandeProductRepository : ICommandeProductRepository
    {
        private readonly ApiDbContext apiDbContext;
        public CommandeProductRepository(ApiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }
        public async Task AddCommandeProductAsync(CommandeProduct commandeProduct)
        {
            await apiDbContext.commandeProducts.AddAsync(commandeProduct);
            await apiDbContext.SaveChangesAsync();
        }
        public async Task DeleteCommandeProductAsync(int CommandeId, string ProductId)
        {
            CommandeProduct? commandeProduct = await apiDbContext.commandeProducts.FirstOrDefaultAsync(x => x.CommandeId == CommandeId && x.ProductId == ProductId);
            if (commandeProduct != null)
            {
                apiDbContext.commandeProducts.Remove(commandeProduct);
                await apiDbContext.SaveChangesAsync();
            }
        }
        public async Task<List<CommandeProduct>> GetAllCommandeProductsAsync()
        {
            return await apiDbContext.commandeProducts.ToListAsync();
        }
        public async Task<CommandeProduct?> GetCommandeProductByIdAsync(int CommandeId, string ProductId)
        {
            CommandeProduct? commandeProduct = await apiDbContext.commandeProducts.Include(x => x.Product).Include(x => x.Commande).FirstOrDefaultAsync(x => x.CommandeId == CommandeId && x.ProductId == ProductId);

            return commandeProduct;

        }
        public async Task UpdateCommandeProductAsync(CommandeProduct commandeProduct)
        {
            var existingCommandeProduct = await apiDbContext.commandeProducts.FirstOrDefaultAsync(x => x.CommandeId == commandeProduct.CommandeId && x.ProductId == commandeProduct.ProductId);
            if (existingCommandeProduct != null)
            {
                apiDbContext.Entry(existingCommandeProduct).CurrentValues.SetValues(commandeProduct);
                await apiDbContext.SaveChangesAsync();
            }
        }

    }
}
