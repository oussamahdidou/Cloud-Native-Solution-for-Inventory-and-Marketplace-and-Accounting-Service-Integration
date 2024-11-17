using MarketplaceService.Application.Dtos.Commande;
using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Interfaces
{
    public interface ICommandeService
    {
        Task<List<CommandeItem>> GetUserCommandes(string CustomerId);
        Task<CommandeDetail> GetCommandeDetail(int Id);
        Task ConfirmeCommande(string PaymentId);

    }
}
