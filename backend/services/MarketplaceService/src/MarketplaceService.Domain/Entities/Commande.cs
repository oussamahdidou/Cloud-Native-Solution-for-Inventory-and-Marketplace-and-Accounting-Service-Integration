using System.ComponentModel.DataAnnotations;

namespace MarketplaceService.Domain.Entities
{
    public class Commande
    {
        [Key]
        public int CommandeId { get; set; }
        public string? PayementId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public double TotaleAmount { get; set; }
        public string CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<CommandeProduct> CommandeProducts { get; set; } = new List<CommandeProduct>();

    }
}
