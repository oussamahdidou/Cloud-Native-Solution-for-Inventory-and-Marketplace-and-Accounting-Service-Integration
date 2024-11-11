using MarketplaceService.Application.Dtos.Cart;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Application.Mappers;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        private readonly ICartProductRepository cartProductRepository;

        public CartService(ICartRepository cartRepository, ICartProductRepository cartProductRepository)
        {
            this.cartRepository = cartRepository;
            this.cartProductRepository = cartProductRepository;
        }

        public async Task AddProductToCart(AddProductToCartDto addProductToCartDto)
        {
            if (await cartProductRepository.GetCartProductByIdAsync(addProductToCartDto.CartId,addProductToCartDto.ProductId)!=null)
            {
                CartProduct cartProduct = new CartProduct()
                {
                    ProductId = addProductToCartDto.ProductId,
                    CartId = addProductToCartDto.CartId,
                    Quantity = 1
                };
                await cartProductRepository.AddCartProductAsync(cartProduct);
            }
           
        }

        public async Task CartCheckout(string CustomerId)
        {
           Cart cart=  await cartRepository.GetCartByCustomerAsync(CustomerId);
            foreach (var item in cart.CartProducts)
            {
                if(item.Product.Quantity < item.Quantity)
                {
                    throw new Exception($"Stock du produit {item.Product.Name} epuisee");
                }
                
            }
        }

        public async Task DecreaseProductQuantity(UpdateCartItemDto updateCartItemDto)
        {
            CartProduct cartProduct = await cartProductRepository.GetCartProductByIdAsync(updateCartItemDto.CartId, updateCartItemDto.ProductId);
            if (cartProduct != null)
            {
                cartProduct.Quantity--;
                await cartProductRepository.UpdateCartProductAsync(cartProduct);
            }
        }

        public async Task<CartDetail> GetCart(string CustomerId)
        {
            Cart cart = await cartRepository.GetCartByCustomerAsync(CustomerId);
            return cart.FromCartToDetail();
        }

        public async Task IncreaseProductQuantity(UpdateCartItemDto updateCartItemDto)
        {
            CartProduct cartProduct = await cartProductRepository.GetCartProductByIdAsync(updateCartItemDto.CartId, updateCartItemDto.ProductId);
            if (cartProduct != null)
            {
                cartProduct.Quantity++;
                await cartProductRepository.UpdateCartProductAsync(cartProduct);
            }
        }

        public async Task RemoveProductFromCart(UpdateCartItemDto updateCartItemDto)
        {
            await cartProductRepository.DeleteCartProductAsync(updateCartItemDto.CartId, updateCartItemDto.ProductId);
        }
    }
}
