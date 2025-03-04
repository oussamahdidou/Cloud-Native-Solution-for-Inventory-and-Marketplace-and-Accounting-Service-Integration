namespace MarketplaceService.Domain.Entities
{
    public class CartProduct
    {
        public string ProductId { get; set; }

        public int CartId { get; set; }
        public int Quantity { get; set; }

        public Product? Product { get; set; }

        public Cart? Cart { get; set; }
    }
}
