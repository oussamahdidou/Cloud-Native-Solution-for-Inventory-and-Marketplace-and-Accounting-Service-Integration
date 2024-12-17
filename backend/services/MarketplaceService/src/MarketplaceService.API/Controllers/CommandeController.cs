using MarketplaceService.Application.Dtos.Commande;
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
    public class CommandeController : ControllerBase
    {
        private readonly ICommandeService commandeService;
        private readonly ICustomerService customerService;

        public CommandeController(ICommandeService commandeService, ICustomerService customerService)
        {
            this.commandeService = commandeService;
            this.customerService = customerService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> getUserCommandes()
        {
            string username = User.GetUsername();
            Customer customer = await customerService.GetCustomerByUsername(username);
            List<CommandeItem> commandes =await commandeService.GetUserCommandes(customer.CustomerId);
            return Ok(commandes);
        }
        [HttpGet("{Id:int}")]
        [Authorize]
        public async Task<IActionResult> GetCommandeDetail([FromRoute] int Id)
        {
        
            CommandeDetail commande = await commandeService.GetCommandeDetail(Id);
            return Ok(commande);
        }
    }
}
