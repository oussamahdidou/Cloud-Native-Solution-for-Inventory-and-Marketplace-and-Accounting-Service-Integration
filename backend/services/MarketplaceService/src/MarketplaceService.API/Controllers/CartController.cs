using MarketplaceService.Application.Dtos.Cart;
using MarketplaceService.Application.Extensions;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly ICustomerService customerService;

        public CartController(ICartService cartService, ICustomerService customerService)
        {
            this.cartService = cartService;
            this.customerService = customerService;
        }
        [Authorize]
        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart()
        {
            try
            {
                string username = User.GetUsername();
                Customer customer = await customerService.GetCustomerByUsername(username);
                CartDetail cartDetail = await cartService.GetCart(customer.CustomerId);
                return Ok(cartDetail);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("AddProductToCart")]
        public async Task<IActionResult> AddProductToCart([FromBody] AddProductToCartDto addProductToCartDto)
        {
            try
            {
                await cartService.AddProductToCart(addProductToCartDto);
                return Ok("product added to cart successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("RemoveProductFromCart")]
        public async Task<IActionResult> RemoveProductFromCart([FromBody] UpdateCartItemDto updateCartItemDto)
        {
            try
            {
                await cartService.RemoveProductFromCart(updateCartItemDto);
                return Ok("product removed from cart successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [Authorize]
        [HttpPost("DecreaseProductQuantity")]
        public async Task<IActionResult> DecreaseProductQuantity([FromBody] UpdateCartItemDto updateCartItemDto)
        {
            try
            {
                await cartService.DecreaseProductQuantity(updateCartItemDto);
                return Ok("decrease product quantity in cart successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("IncreaseProductQuantity")]
        public async Task<IActionResult> IncreaseProductQuantity([FromBody] UpdateCartItemDto updateCartItemDto)
        {
            try
            {
                await cartService.IncreaseProductQuantity(updateCartItemDto);
                return Ok("increase product quantity in cart successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("Checkout")]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                string username = User.GetUsername();
                Customer customer = await customerService.GetCustomerByUsername(username);
                Commande commande = await cartService.CartCheckout(customer.CustomerId);
                return Ok(commande);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
