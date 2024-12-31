using MarketplaceService.Application.Dtos.Paypal;
using MarketplaceService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaypalController : ControllerBase
    {
        private readonly IPaypalService paypalService;
        private readonly ICommandeService commandeService;
        public PaypalController(IPaypalService paypalService, ICommandeService commandeService)
        {
            this.paypalService = paypalService;
            this.commandeService = commandeService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePayment([FromBody] PaypalRequest paypalRequest)
        {
            CreatePaymentDto createPaymentDto = new CreatePaymentDto()
            {
                CommandeId = paypalRequest.CommandeId,
                Amount = paypalRequest.Amount,
                Description = "pays commande",
                CancelUrl = "http://localhost:5000/gateway/marketplace/Paypal/cancel",
                ReturnUrl = "http://localhost:5000/gateway/marketplace/Paypal/success"

            };
            var payment = await paypalService.CreatePayment(createPaymentDto);

            return Ok(new { approvalUrl = payment.GetApprovalUrl() });
        }
        [HttpGet("success")]
        public async Task<IActionResult> Success([FromQuery] string paymentId, string token, string PayerID)
        {
            await commandeService.ConfirmeCommande(paymentId);
            await Console.Out.WriteLineAsync("Payment Successful");
            // Handle success logic here
            return Ok("Payment Successful");
        }

        [HttpGet("cancel")]
        public async Task<IActionResult> Cancel()
        {
            // Handle cancel logic here
            await Console.Out.WriteLineAsync("Payment Cancelled");

            return Ok("Payment Cancelled");
        }
    }
}
