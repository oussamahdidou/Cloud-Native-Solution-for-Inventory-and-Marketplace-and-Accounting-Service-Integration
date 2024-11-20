using MarketplaceService.Application.Dtos.Commande;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Application.Mappers;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Services
{
    public class CommandeService : ICommandeService
    {
        private readonly ICommandeRepository commandeRepository;

        public CommandeService(ICommandeRepository commandeRepository)
        {
            this.commandeRepository = commandeRepository;
        }

        public async Task<CommandeDetail> GetCommandeDetail(int Id)
        {
          Commande commande =  await commandeRepository.GetCommandeByIdAsync(Id);
            return commande.FromCommandeToDetail();
        }

        public async Task<List<CommandeItem>> GetUserCommandes(string CustomerId)
        {
           List<Commande> commandes = await commandeRepository.GetCommandesByCustomerAsync(CustomerId);
           return commandes.Select(x=>x.FromCommandeToItem()).ToList();
        }

        public async Task ConfirmeCommande(string PaymentId)
        {
            Commande commande= await  commandeRepository.GetCommandesByPaymentIdAsync(PaymentId);
            commande.Status = "Confirmed";
            await commandeRepository.UpdateCommandeAsync(commande);
        }
    }
}
