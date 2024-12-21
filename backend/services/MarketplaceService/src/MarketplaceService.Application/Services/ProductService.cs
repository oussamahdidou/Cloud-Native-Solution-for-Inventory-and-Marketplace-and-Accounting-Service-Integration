using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Application.Mappers;
using MarketplaceService.Domain.Caching;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Queries;
using MarketplaceService.Domain.Repositories;
using Newtonsoft.Json;

namespace MarketplaceService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IRedisCachingService redisCachingService;

        public ProductService(IProductRepository productRepository, IRedisCachingService redisCachingService)
        {
            this.productRepository = productRepository;
            this.redisCachingService = redisCachingService;
        }
        public async Task<ProductDetail> GetProductDetail(string productId)
        {
            try
            {
                ProductDetail? productDetail = await redisCachingService.GetElementByKeyAsync<ProductDetail>(productId);
                if (productDetail != null)
                {
                    Console.WriteLine($"Found in cache: {JsonConvert.SerializeObject(productDetail)}");
                    return productDetail;
                }
                Product product = await productRepository.GetProductByIdAsync(productId);
                if (product == null) throw new KeyNotFoundException("product not found");
                Console.WriteLine($"Mapped Product: {JsonConvert.SerializeObject(product)}");

                productDetail = product.FromProductToDetail();
                Console.WriteLine($"Mapped ProductDetail: {JsonConvert.SerializeObject(productDetail)}");
                return await redisCachingService.AddItemToCacheAsync(productDetail, productId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductItem>> GetProductItems(ProductQuery productQuery)
        {
            try
            {
                List<Product> products = await productRepository.GetAllProductsAsync(productQuery);
                return products.Select(x => x.FromProductToItem()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
