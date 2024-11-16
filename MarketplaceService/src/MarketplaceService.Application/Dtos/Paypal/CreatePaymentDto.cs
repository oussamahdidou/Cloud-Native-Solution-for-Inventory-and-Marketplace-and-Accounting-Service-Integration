using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Dtos.Paypal
{
    public class CreatePaymentDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD"; // Default to USD, can be overridden
        public string Description { get; set; }
        public string ReturnUrl { get; set; }
        public string CancelUrl { get; set; }
    }
}
