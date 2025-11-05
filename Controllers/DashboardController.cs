using DocumentinAPI.Domain.DTOs.Dashboard;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("dashboard")]
    [Authorize]
    public class DashboardController : BaseController
    {

        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém informações de documentos para o dashboard.
        /// </summary>
        /// <response code="200">Retorna as informações dos documentos.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("documents")]
        public async Task<IActionResult> GetDocumentsInfoDashAsync([FromQuery] DashboardRequestDTO dto)
        {
            var ret = await _service.GetDocumentDashboardInfoAsync(dto, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpGet("documentsMonths")]
        public async Task<IActionResult> GetDocumentMonthDashInfoAsync([FromQuery] DashboardRequestDTO dto)
        {
            var ret = await _service.GetDocumentMonthDashInfoAsync(dto, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

    }
}
