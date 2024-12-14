using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Application.Mappers;
using MarketplaceService.Domain.Caching;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Queries;
using MarketplaceService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (productDetail != null) { return productDetail; }
                Product product = await productRepository.GetProductByIdAsync(productId);
                if(product==null) throw new KeyNotFoundException();
                return await redisCachingService.AddItemToCacheAsync<ProductDetail>(product.FromProductToDetail(),productId);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<List<ProductItem>> GetProductItems(ProductQuery productQuery)
        {
            try 
            {
                List<Product> products = await productRepository.GetAllProductsAsync(productQuery);
                return products.Select(x=>x.FromProductToItem()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
