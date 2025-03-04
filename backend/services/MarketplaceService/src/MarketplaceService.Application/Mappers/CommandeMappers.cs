using MarketplaceService.Application.Dtos.Commande;
using MarketplaceService.Domain.Entities;

namespace MarketplaceService.Application.Mappers
{
    public static class CommandeMappers
    {
        public static CommandeDetail FromCommandeToDetail(this Commande commande)
        {
            return new CommandeDetail()
            {
                CommandeId = commande.CommandeId,
                Status = commande.Status,
                TotalAmount = commande.TotaleAmount,
                Date = commande.OrderDate,
            };
        }
        public static CommandeItem FromCommandeToItem(this Commande commande)
        {
            return new CommandeItem()
            {
                CommandeId = commande.CommandeId,
                Date = commande.OrderDate,
            };
        }
    }
}
