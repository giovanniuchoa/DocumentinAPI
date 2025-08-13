using DocumentinAPI.Domain.DTOs.Template;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Template")]
    [Authorize]
    public class TemplateController : BaseController
    {

        private readonly ITemplateService _service;

        public TemplateController(ITemplateService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém um template pelo identificador.
        /// </summary>
        /// <response code="200">Retorna o template correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetTemplateById/{templateId}")]
        public async Task<IActionResult> GetTemplateByIdAsync(int templateId)
        {

            var ret = await _service.GetTemplateByIdAsync(templateId, ssn);

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
        /// Obtém uma lista dos templates.
        /// </summary>
        /// <response code="200">Retorna uma lista dos templates.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListTemplate")]
        public async Task<IActionResult> GetListTemplateAsync()
        {

            var ret = await _service.GetListTemplateAsync(ssn);

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
        /// Insere um template novo.
        /// </summary>
        /// <response code="200">Retorna o template adicionado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddTemplate")]
        public async Task<IActionResult> AddTemplateAsync([FromBody] TemplateRequestDTO dto)
        {

            var ret = await _service.AddTemplateAsync(dto, ssn);

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
        /// Atualiza um template.
        /// </summary>
        /// <response code="200">Retorna o template atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdateTemplate")]
        public async Task<IActionResult> UpdateTemplateAsync([FromBody] TemplateRequestDTO dto)
        {

            var ret = await _service.UpdateTemplateAsync(dto, ssn);

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
        /// Alterna o status (IsActive) de um template.
        /// </summary>
        /// <response code="200">Retorna o template atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("ToggleStatusTemplate/{templateId}")]
        public async Task<IActionResult> ToggleStatusTemplateAsync(int templateId)
        {

            var ret = await _service.ToggleStatusTemplateAsync(templateId, ssn);

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
