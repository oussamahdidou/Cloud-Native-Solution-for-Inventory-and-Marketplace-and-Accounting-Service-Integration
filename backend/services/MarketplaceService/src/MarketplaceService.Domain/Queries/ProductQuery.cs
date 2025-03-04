namespace MarketplaceService.Domain.Queries
{
    public class ProductQuery
    {
        public string? CategoryId { get; set; }
        public string? Marque { get; set; }
        public string? TextQuery { get; set; }
        public bool SortByPrice { get; set; }
        public bool SortByQuantity { get; set; }
        public bool Descending { get; set; }
    }
}
