using MarketplaceService.Application.Dtos.Cart;
using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Mappers
{
    public static class CartMappers
    {
        public static CartDetail FromCartToDetail(this Cart cart)
        {
            return new CartDetail()
            {
                CartItems = cart.CartProducts.Select(x=>x.FromProductToCartItem()).ToList(),
                TotalAmount = cart.TotalAmount,
            };
        }
        public static CartItem FromProductToCartItem(this CartProduct cartProduct)
        {
            return new CartItem()
            {
                ProductId = cartProduct.Product.ProductId,
                Quantity = cartProduct.Product.Quantity,
                Thumbnail = cartProduct.Product.Thumbnail,
                Title = cartProduct.Product.Name,
                UnityPrice = cartProduct.Product.Price,
            };
        }
    }
}
