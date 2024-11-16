using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Dtos.Products
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string MarqueName { get; set; }
        public string MarqueIcon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryId { get; set; }
        public string CategoryThumbnail { get; set; }
        public string CategoryName { get; set; }

    }
}
