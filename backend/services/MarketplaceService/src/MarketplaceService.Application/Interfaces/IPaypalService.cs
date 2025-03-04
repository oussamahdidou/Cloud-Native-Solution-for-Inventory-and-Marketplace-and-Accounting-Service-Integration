using MarketplaceService.Application.Dtos.Paypal;
using PayPal.Api;

namespace MarketplaceService.Application.Interfaces
{
    public interface IPaypalService
    {
        Task<Payment> CreatePayment(CreatePaymentDto createPaymentDto);
    }
}
