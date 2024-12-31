using ComptabiliteService.Entities;
using ComptabiliteService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComptabiliteService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcritureComptableController : ControllerBase
    {
        private readonly IEcritureComptableService ecritureComptableService;
        public EcritureComptableController(IEcritureComptableService ecritureComptableService)
        {
            this.ecritureComptableService = ecritureComptableService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEcritureComptable([FromBody] EcritureComptable ecritureComptable)
        {
            try
            {
                var result = await ecritureComptableService.CreateEcritureComptable(ecritureComptable);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
