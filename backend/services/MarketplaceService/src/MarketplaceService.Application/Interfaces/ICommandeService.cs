using MarketplaceService.Application.Dtos.Commande;

namespace MarketplaceService.Application.Interfaces
{
    public interface ICommandeService
    {
        Task<List<CommandeItem>> GetUserCommandes(string CustomerId);
        Task<CommandeDetail> GetCommandeDetail(int Id);
        Task ConfirmeCommande(string PaymentId);

    }
}
