using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Queries
{
    public class ProductQuery
    {
        public int? CategoryId { get; set; }
        public string? Marque { get; set; }
        public string? TextQuery { get; set; }
        public bool SortByPrice { get; set; }
        public bool SortByQuantity { get; set; }
        public bool Descending { get; set; }
    }
}
