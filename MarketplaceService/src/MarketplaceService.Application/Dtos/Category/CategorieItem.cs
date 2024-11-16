using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Dtos.Category
{
    public class CategorieItem
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }
    }
}
