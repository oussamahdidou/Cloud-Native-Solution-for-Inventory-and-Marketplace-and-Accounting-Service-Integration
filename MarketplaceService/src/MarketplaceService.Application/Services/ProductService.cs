using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Application.Mappers;
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
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<ProductDetail> GetProductDetail(int productId)
        {
            try
            {
               Product product = await productRepository.GetProductByIdAsync(productId);
                return product.FromProductToDetail();
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
