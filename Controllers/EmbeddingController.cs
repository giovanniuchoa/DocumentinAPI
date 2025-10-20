using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{
    [Route("Embedding")]
    [Authorize]
    public class EmbeddingController : BaseController
    {

        private readonly IEmbeddingService _service;

        public EmbeddingController(IEmbeddingService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém uma lista de floats que correspondem ao embedding do conteúdo enviado.
        /// </summary>
        /// <response code="200">Retorna o embedding do input.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("GetEmbedding")]
        public async Task<IActionResult> GetEmbeddingAsync([FromBody] string input)
        {

            var ret = await _service.GetEmbeddingAsync(input, ssn);

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
