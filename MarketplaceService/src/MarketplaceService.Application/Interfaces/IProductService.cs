using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductItem>> GetProductItems(ProductQuery productQuery);
        Task<ProductDetail> GetProductDetail(string productId);

    }
}
