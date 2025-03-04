namespace MarketplaceService.Application.Dtos.Products
{
    public class ProductItem
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Thumbnail { get; set; }
        public int Quantity { get; set; }
    }
}
