using MarketplaceService.Application.Dtos.Cart;
using MarketplaceService.Domain.Entities;

namespace MarketplaceService.Application.Mappers
{
    public static class CartMappers
    {
        public static CartDetail FromCartToDetail(this Cart cart)
        {
            return new CartDetail()
            {
                CartId = cart.CartId,
                CartItems = cart.CartProducts.Select(x => x.FromProductToCartItem()).ToList(),
                TotalAmount = cart.TotalAmount,

            };
        }
        public static CartItem FromProductToCartItem(this CartProduct cartProduct)
        {
            return new CartItem()
            {
                ProductId = cartProduct.Product.ProductId,
                Quantity = cartProduct.Quantity,
                Thumbnail = cartProduct.Product.Thumbnail,
                Title = cartProduct.Product.Name,
                UnityPrice = cartProduct.Product.Price,
            };
        }
        public static CommandeProduct FromCartItemToCommandeItem(this CartProduct cartProduct)
        {
            return new CommandeProduct()
            {
                ProductId = cartProduct.ProductId,
                Quantity = cartProduct.Quantity
            };
        }
    }
}
