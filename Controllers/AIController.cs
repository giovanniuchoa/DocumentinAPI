using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.OpenAIConfig;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("AI")]
    [Authorize]
    public class AIController : BaseController
    {

        private readonly IAIService _service;

        public AIController(IAIService service)
        {
            _service = service;
        }


        /// <summary>
        /// Resume um conteúdo de um Documento em Markdown (.md) usando OpenAI .
        /// </summary>
        /// <response code="200">Retorna o conteúdo resumido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("GenerateSummary")]
        [ProducesResponseType(typeof(Retorno<AIResponseDTO>), 200)]
        public async Task<IActionResult> GenerateSummaryAsync([FromBody] AIRequestDTO dto)
        {

            var ret = await _service.GenerateSummaryAsync(dto, ssn);

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
        /// Busca uma configuração do OpenAI pelo id.
        /// </summary>
        /// <response code="200">Retorna uma configuração de OpenAI.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetOpenAIConfigByCompany")]
        [ProducesResponseType(typeof(Retorno<OpenAIConfigResponseDTO>), 200)]
        public async Task<IActionResult> GetOpenAIConfigByCompanyAsync()
        {

            var ret = await _service.GetOpenAIConfigByCompanyAsync(ssn);

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
        /// Cadastra uma configuração do OpenAI.
        /// </summary>
        /// <response code="200">Retorna uma configuração de OpenAI.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddOpenAIConfig")]
        [ProducesResponseType(typeof(Retorno<OpenAIConfigResponseDTO>), 200)]
        public async Task<IActionResult> AddOpenAIConfigAsync([FromBody] OpenAIConfigRequestDTO dto)
        {

            var ret = await _service.AddOpenAIConfigAsync(dto, ssn);

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
        /// Atualiza uma configuração do OpenAI.
        /// </summary>
        /// <response code="200">Retorna uma configuração de OpenAI.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdateOpenAIConfig")]
        [ProducesResponseType(typeof(Retorno<OpenAIConfigResponseDTO>), 200)]
        public async Task<IActionResult> UpdateOpenAIConfigAsync([FromBody] OpenAIConfigRequestDTO dto)
        {

            var ret = await _service.UpdateOpenAIConfigAsync(dto, ssn);

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
