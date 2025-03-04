using System.ComponentModel.DataAnnotations;

namespace MarketplaceService.Domain.Entities
{
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
