﻿using MarketplaceService.Application.Dtos.Cart;
using MarketplaceService.Domain.Entities;

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
