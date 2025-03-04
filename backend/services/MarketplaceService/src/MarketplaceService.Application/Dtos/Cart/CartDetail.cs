namespace MarketplaceService.Application.Dtos.Cart
{
    public class CartDetail
    {
        public int CartId { get; set; }
        public double TotalAmount { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
