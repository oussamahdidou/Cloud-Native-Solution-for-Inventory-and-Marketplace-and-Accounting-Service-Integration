using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Dtos.Paypal
{
    public class PaypalRequest
    {
        public decimal Amount { get; set; }
        public int CommandeId { get; set; }
    }
}
