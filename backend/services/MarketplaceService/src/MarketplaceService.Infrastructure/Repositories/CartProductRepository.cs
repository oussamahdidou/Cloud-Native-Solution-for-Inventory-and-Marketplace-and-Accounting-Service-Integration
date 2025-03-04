﻿using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using MarketplaceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceService.Infrastructure.Repositories
{
    public class CartProductRepository : ICartProductRepository
    {
        private readonly ApiDbContext apiDbContext;

        public CartProductRepository(ApiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }

        public async Task AddCartProductAsync(CartProduct cartProduct)
        {
            await apiDbContext.cartProducts.AddAsync(cartProduct);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task DeleteCartProductAsync(int CartId, string ProductId)
        {
            CartProduct? cartProduct = await apiDbContext.cartProducts.FirstOrDefaultAsync(x => x.CartId == CartId && x.ProductId == ProductId);
            if (cartProduct != null)
            {
                apiDbContext.cartProducts.Remove(cartProduct);
                await apiDbContext.SaveChangesAsync();
            }
        }



        public async Task<List<CartProduct>> GetAllCartProductsAsync()
        {
            return await apiDbContext.cartProducts.ToListAsync();
        }

        public async Task<CartProduct> GetCartProductByIdAsync(int CartId, string ProductId)
        {
            CartProduct? cartProduct = await apiDbContext.cartProducts.Include(x => x.Product).Include(x => x.Cart).FirstOrDefaultAsync(x => x.CartId == CartId && x.ProductId == ProductId);

            return cartProduct;

        }



        public async Task UpdateCartProductAsync(CartProduct cartProduct)
        {
            var existingCartProduct = await apiDbContext.cartProducts.FirstOrDefaultAsync(x => x.CartId == cartProduct.CartId && x.ProductId == cartProduct.ProductId);
            if (existingCartProduct != null)
            {
                apiDbContext.Entry(existingCartProduct).CurrentValues.SetValues(cartProduct);
                await apiDbContext.SaveChangesAsync();
            }
        }


    }
}
