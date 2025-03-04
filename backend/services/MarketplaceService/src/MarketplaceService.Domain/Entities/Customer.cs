using System.ComponentModel.DataAnnotations;

namespace MarketplaceService.Domain.Entities
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }
        public string UserName { get; set; }
        public List<Commande> Commandes { get; set; } = new List<Commande>();
    }
}
