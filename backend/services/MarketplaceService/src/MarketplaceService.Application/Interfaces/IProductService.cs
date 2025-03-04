using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Domain.Queries;

namespace MarketplaceService.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductItem>> GetProductItems(ProductQuery productQuery);
        Task<ProductDetail> GetProductDetail(string productId);

    }
}
