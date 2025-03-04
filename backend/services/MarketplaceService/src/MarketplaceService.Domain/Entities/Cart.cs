using System.ComponentModel.DataAnnotations;

namespace MarketplaceService.Domain.Entities
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public double TotalAmount { get; set; }
        public string CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    }
}
