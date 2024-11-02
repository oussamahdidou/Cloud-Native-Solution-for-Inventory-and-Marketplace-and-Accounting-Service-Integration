using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
