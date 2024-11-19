using MarketplaceService.Application.Dtos.Paypal;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Interfaces
{
    public interface IPaypalService
    {
        Task<Payment> CreatePayment(CreatePaymentDto createPaymentDto);
    }
}
