using EventsContracts.EventsContracts;
using MarketplaceService.Application.Dtos.Cart;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Application.Mappers;
using MarketplaceService.Domain.Caching;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Events.Commande;
using MarketplaceService.Domain.Repositories;
using MassTransit;

namespace MarketplaceService.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        private readonly ICartProductRepository cartProductRepository;
        private readonly ICommandeRepository commandeRepository;
        private readonly IProductRepository productRepository;
        private readonly IBus bus;
        private readonly IRedisCachingService redisCachingService;
        public CartService(ICartRepository cartRepository, ICartProductRepository cartProductRepository, ICommandeRepository commandeRepository, IBus bus, IProductRepository productRepository, IRedisCachingService redisCachingService)
        {
            this.cartRepository = cartRepository;
            this.cartProductRepository = cartProductRepository;
            this.commandeRepository = commandeRepository;
            this.bus = bus;
            this.productRepository = productRepository;
            this.redisCachingService = redisCachingService;
        }

        public async Task AddProductToCart(AddProductToCartDto addProductToCartDto)
        {
            try
            {
                if (await cartProductRepository.GetCartProductByIdAsync(addProductToCartDto.CartId, addProductToCartDto.ProductId) == null)
                {
                    CartProduct cartProduct = new CartProduct()
                    {
                        ProductId = addProductToCartDto.ProductId,
                        CartId = addProductToCartDto.CartId,
                        Quantity = 1
                    };
                    Cart cart = await cartRepository.GetCartByIdAsync(addProductToCartDto.CartId);
                    Product product = await productRepository.GetProductByIdAsync(addProductToCartDto.ProductId);
                    cart.TotalAmount += product.Price;
                    await cartRepository.UpdateCartAsync(cart);
                    await cartProductRepository.AddCartProductAsync(cartProduct);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Commande> CartCheckout(string CustomerId)
        {

            try
            {
                Cart cart = await cartRepository.GetCartByCustomerAsync(CustomerId);
                var insufficientStockItem = cart.CartProducts
                    .FirstOrDefault(item => item.Product.Quantity < item.Quantity);

                if (insufficientStockItem != null)
                {
                    throw new Exception($"Stock du produit {insufficientStockItem.Product.Name} épuisé");
                }
                List<CommandeProduct> commandeProducts = cart.CartProducts.Select(x => x.FromCartItemToCommandeItem()).ToList();

                Commande commande = new Commande()
                {
                    OrderDate = DateTime.Now,
                    Status = "Order Confirmed",
                    CustomerId = CustomerId,
                    TotaleAmount = cart.TotalAmount,
                    CommandeProducts = commandeProducts
                };

                await commandeRepository.AddCommandeAsync(commande);
                List<CartProduct> cartProducts = cart.CartProducts.ToList();
                foreach (var item in cartProducts)
                {
                    await cartProductRepository.DeleteCartProductAsync(item.CartId, item.ProductId);
                }
                cart.TotalAmount = 0;
                await cartRepository.UpdateCartAsync(cart);
                CommandeConfirmedEvent commandeConfirmedEvent = new CommandeConfirmedEvent()
                {
                    Date = commande.OrderDate,
                    Items = commandeProducts.Select(x => new CommandeItemEvent()
                    {
                        ItemId = x.ProductId,
                        Quantity = x.Quantity
                    }).Cast<ICommandeItemEvent>().ToList()
                };

                await bus.Publish<ICommandeConfirmedEvent>(commandeConfirmedEvent);
                return commande;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DecreaseProductQuantity(UpdateCartItemDto updateCartItemDto)
        {
            try
            {
                CartProduct? cartProduct = await cartProductRepository.GetCartProductByIdAsync(updateCartItemDto.CartId, updateCartItemDto.ProductId);
                if (cartProduct != null)
                {
                    cartProduct.Quantity--;
                    Cart cart = await cartRepository.GetCartByIdAsync(updateCartItemDto.CartId);
                    Product product = await productRepository.GetProductByIdAsync(updateCartItemDto.ProductId);
                    cart.TotalAmount -= product.Price;
                    await cartRepository.UpdateCartAsync(cart);
                    await cartProductRepository.UpdateCartProductAsync(cartProduct);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CartDetail> GetCart(string CustomerId)
        {
            try
            {
                Cart cart = await cartRepository.GetCartByCustomerAsync(CustomerId);
                return cart.FromCartToDetail();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task IncreaseProductQuantity(UpdateCartItemDto updateCartItemDto)
        {
            try
            {
                CartProduct cartProduct = await cartProductRepository.GetCartProductByIdAsync(updateCartItemDto.CartId, updateCartItemDto.ProductId);
                if (cartProduct != null)
                {
                    cartProduct.Quantity++;
                    Cart cart = await cartRepository.GetCartByIdAsync(updateCartItemDto.CartId);
                    Product product = await productRepository.GetProductByIdAsync(updateCartItemDto.ProductId);
                    cart.TotalAmount += product.Price;
                    await cartRepository.UpdateCartAsync(cart);
                    await cartProductRepository.UpdateCartProductAsync(cartProduct);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveProductFromCart(UpdateCartItemDto updateCartItemDto)
        {
            try
            {
                CartProduct cartProduct = await cartProductRepository.GetCartProductByIdAsync(updateCartItemDto.CartId, updateCartItemDto.ProductId);
                cartProduct.Cart.TotalAmount -= (cartProduct.Product.Price * cartProduct.Quantity);
                await cartRepository.UpdateCartAsync(cartProduct.Cart);
                await cartProductRepository.DeleteCartProductAsync(updateCartItemDto.CartId, updateCartItemDto.ProductId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
