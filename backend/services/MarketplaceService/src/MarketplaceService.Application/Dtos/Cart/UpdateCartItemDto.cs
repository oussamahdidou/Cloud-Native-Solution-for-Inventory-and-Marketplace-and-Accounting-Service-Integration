using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Dtos.Cart
{
    public class UpdateCartItemDto
    {
        public string ProductId { get; set; }
        public int CartId { get; set; }
    }
}
