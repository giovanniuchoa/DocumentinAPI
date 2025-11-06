using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Dashboard;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.DocumentValidation;
using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.Utils;
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
        [ProducesResponseType(typeof(Retorno<DocumentDashboardResponseDTO>), 200)]
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

        /// <summary>
        /// Obtém informações de documentos por mês para o dashboard.
        /// </summary>
        /// <response code="200">Retorna as informações dos documentos.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [ProducesResponseType(typeof(Retorno<List<DocumentMonthDashResponseDTO>>), 200)]
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

        /// <summary>
        /// Obtém informações sobre o uso de IA para o dashboard.
        /// </summary>
        /// <response code="200">Retorna as informações do uso de IA.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [ProducesResponseType(typeof(Retorno<AIDashboardResponseDTO>), 200)]
        [HttpGet("ai")]
        public async Task<IActionResult> GetAIDashboardInfoAsync([FromQuery] DashboardRequestDTO dto)
        {
            var ret = await _service.GetAIDashboardInfoAsync(dto, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        /// <summary>
        /// Obtém informações de uso de IA por usuário (ranking).
        /// </summary>
        /// <response code="200">Retorna as informações do uso de IA por usuário.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [ProducesResponseType(typeof(Retorno<List<DocumentMonthDashResponseDTO>>), 200)]
        [HttpGet("aiUsers")]
        public async Task<IActionResult> GetAIUsersUsageDashInfoAsync([FromQuery] DashboardRequestDTO dto)
        {
            var ret = await _service.GetAIUsersUsageDashInfoAsync(dto, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        /// <summary>
        /// Obtém informações das tarefas para o dashboard.
        /// </summary>
        /// <response code="200">Retorna as informações de tarefas.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [ProducesResponseType(typeof(Retorno<TaskDashResponseDTO>), 200)]
        [HttpGet("task")]
        public async Task<IActionResult> GetTaskInfoDashAsync([FromQuery] DashboardRequestDTO dto)
        {
            var ret = await _service.GetTaskInfoDashAsync(dto, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        /// <summary>
        /// Obtém informações de tarefas por prioridade.
        /// </summary>
        /// <response code="200">Retorna as informações das tarefas por prioridade.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [ProducesResponseType(typeof(Retorno<List<TaskPriorityDashResponseDTO>>), 200)]
        [HttpGet("taskPriority")]
        public async Task<IActionResult> GetTaskPriorityDashInfoAsync([FromQuery] DashboardRequestDTO dto)
        {
            var ret = await _service.GetTaskPriorityDashInfoAsync(dto, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        /// <summary>
        /// Obtém informações das validações de documento.
        /// </summary>
        /// <response code="200">Retorna as informações das validações de documento.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [ProducesResponseType(typeof(Retorno<DocumentValidationDashResponseDTO>), 200)]
        [HttpGet("documentvalidation")]
        public async Task<IActionResult> GetDocumentValidationDashInfoAsync([FromQuery] DashboardRequestDTO dto)
        {
            var ret = await _service.GetDocumentValidationDashInfoAsync(dto, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        /// <summary>
        /// Obtém informações das validações de documento por usuário.
        /// </summary>
        /// <response code="200">Retorna as informações das validações de documento por usuário.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [ProducesResponseType(typeof(Retorno<List<DocumentValidationUserDashResponseDTO>>), 200)]
        [HttpGet("documentvalidationUsers")]
        public async Task<IActionResult> GetDocumentValidationUsersDashInfoAsync([FromQuery] DashboardRequestDTO dto)
        {
            var ret = await _service.GetDocumentValidationUsersDashInfoAsync(dto, ssn);

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
