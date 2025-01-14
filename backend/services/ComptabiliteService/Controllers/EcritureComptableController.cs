using ComptabiliteService.Dtos;
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
        public async Task<IActionResult> CreateEcritureComptable([FromBody] EcritureComptableDto ecritureComptable)
        {
            try
            {
                await ecritureComptableService.CreateEcritureComptable(ecritureComptable);
                return Ok(ecritureComptable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
