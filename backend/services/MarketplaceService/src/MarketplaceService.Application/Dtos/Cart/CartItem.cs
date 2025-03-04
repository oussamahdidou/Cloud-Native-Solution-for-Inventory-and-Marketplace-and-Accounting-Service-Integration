namespace MarketplaceService.Application.Dtos.Cart
{
    public class CartItem
    {
        public string ProductId { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public int Quantity { get; set; }
        public double UnityPrice { get; set; }
        public double TotalAmount => Quantity * UnityPrice;
    }
}
