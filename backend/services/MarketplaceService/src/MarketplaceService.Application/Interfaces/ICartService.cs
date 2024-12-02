using MarketplaceService.Application.Dtos.Cart;
using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Interfaces
{
    public interface ICartService
    {
        Task<CartDetail> GetCart(string CustomerId);
        Task AddProductToCart(AddProductToCartDto addProductToCartDto);
        Task RemoveProductFromCart(UpdateCartItemDto updateCartItemDto);
        Task IncreaseProductQuantity(UpdateCartItemDto updateCartItemDto);
        Task DecreaseProductQuantity(UpdateCartItemDto updateCartItemDto);
        Task<Commande> CartCheckout(string CustomerId);
    }
}
