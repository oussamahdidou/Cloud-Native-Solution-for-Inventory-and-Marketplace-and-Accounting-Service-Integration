using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using MarketplaceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Infrastructure.Repositories
{
    
    public class CartRepository : ICartRepository
    {
        private readonly apiDbContext apiDbContext;

        public CartRepository(apiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }

        public async Task AddCartAsync(Cart cart)
        {
            await apiDbContext.carts.AddAsync(cart);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task DeleteCartAsync(int id)
        {
            var cart = await apiDbContext.carts.FindAsync(id);
            if (cart != null)
            {
                apiDbContext.carts.Remove(cart);
                await apiDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await apiDbContext.carts.ToListAsync();
        }

        public async Task<Cart> GetCartByIdAsync(int id)
        {
            return await apiDbContext.carts.FindAsync(id);
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            var existingCart = await apiDbContext.carts.FindAsync(cart.CartId);
            if (existingCart != null)
            {
                apiDbContext.Entry(existingCart).CurrentValues.SetValues(cart);
                await apiDbContext.SaveChangesAsync();
            }
        }
    }
}
