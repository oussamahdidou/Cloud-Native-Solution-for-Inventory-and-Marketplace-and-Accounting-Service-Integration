using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Entities
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        public string MarqueName { get; set; }
        public string MarqueIcon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Thumbnail { get; set; }
        public string CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<CommandeProduct> CommandeProducts { get; set; } = new List<CommandeProduct>();
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    }
}
