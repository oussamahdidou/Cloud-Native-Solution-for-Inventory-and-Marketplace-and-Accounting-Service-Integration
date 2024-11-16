using MarketplaceService.Application.Dtos.Paypal;
using MarketplaceService.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using PayPal;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Services
{
    public class PaypalService:IPaypalService
    {
        private readonly string clientId;
        private readonly string clientSecret;
        private readonly string mode;

        public PaypalService(IConfiguration configuration)
        {
            var payPalConfig = configuration.GetSection("PayPal");
            clientId = payPalConfig["ClientId"];
            clientSecret = payPalConfig["ClientSecret"];
            mode = payPalConfig["Mode"];
        }


        public Payment CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var apiContext = new APIContext(new OAuthTokenCredential(clientId, clientSecret).GetAccessToken())
            {
                Config = new Dictionary<string, string> { { "mode", mode } }
            };

            var payment = new Payment
            {
                intent = "sale",
                payer = new Payer { payment_method = "paypal" },
                transactions = new List<Transaction>
            {
                new Transaction
                {
                    description = createPaymentDto.Description,
                    amount = new Amount
                    {
                        currency = createPaymentDto.Currency,
                        total = createPaymentDto.Amount.ToString("F2")
                    }
                }
            },
                redirect_urls = new RedirectUrls
                {
                    return_url = createPaymentDto.ReturnUrl,
                    cancel_url = createPaymentDto.CancelUrl
                }
            };

            return payment.Create(apiContext);
        }
    }
}
