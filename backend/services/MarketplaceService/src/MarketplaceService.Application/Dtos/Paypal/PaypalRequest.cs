namespace MarketplaceService.Application.Dtos.Paypal
{
    public class PaypalRequest
    {
        public decimal Amount { get; set; }
        public int CommandeId { get; set; }
    }
}
