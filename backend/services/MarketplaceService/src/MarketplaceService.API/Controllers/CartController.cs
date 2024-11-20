using MarketplaceService.Application.Dtos.Cart;
using MarketplaceService.Application.Extensions;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            string username = User.GetUsername();
            Customer customer = await customerService.GetCustomerByUsername(username); 
            CartDetail cartDetail = await cartService.GetCart(customer.CustomerId);
            return Ok(cartDetail);
        }
        [HttpPost("AddProductToCart")]
        public async Task<IActionResult> AddProductToCart([FromBody] AddProductToCartDto addProductToCartDto)
        {
           await cartService.AddProductToCart(addProductToCartDto); 
            return Ok();
        }
        [HttpPost("RemoveProductFromCart")]
        public async Task<IActionResult> RemoveProductFromCart([FromBody] UpdateCartItemDto updateCartItemDto)
        {
            await cartService.RemoveProductFromCart(updateCartItemDto);
            return Ok("success");
        }
        [HttpPost("DecreaseProductQuantity")]
        public async Task<IActionResult> DecreaseProductQuantity([FromBody] UpdateCartItemDto updateCartItemDto)
        {
            await cartService.DecreaseProductQuantity(updateCartItemDto);
            return Ok("success");
        }
        [HttpPost("IncreaseProductQuantity")]
        public async Task<IActionResult> IncreaseProductQuantity([FromBody] UpdateCartItemDto updateCartItemDto)
        {
            await cartService.IncreaseProductQuantity(updateCartItemDto);
            return Ok("success");
        }
        [Authorize]
        [HttpGet("Checkout")]
        public async Task<IActionResult> Checkout()
        {
            string username = User.GetUsername();
            Customer customer = await customerService.GetCustomerByUsername(username);
            await cartService.CartCheckout(customer.CustomerId);
            return Ok("success");
        }
    }
}
