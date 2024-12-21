using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Domain.Entities;

namespace MarketplaceService.Application.Mappers
{
    public static class ProductMappers
    {
        public static ProductDetail FromProductToDetail(this Product product)
        {
            return new ProductDetail()
            {
                ProductId = product.ProductId,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Description = product.Description,
                Name = product.Name,
                CategoryThumbnail = product.Category.Thumbnail,
                MarqueIcon = product.MarqueIcon,
                Thumbnail = product.Thumbnail,
                MarqueName = product.MarqueName,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }
        public static ProductItem FromProductToItem(this Product product)
        {
            return new ProductItem()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Thumbnail = product.Thumbnail,
            };
        }
    }
}
