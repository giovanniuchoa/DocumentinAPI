using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("DocumentValidation")]
    [Authorize]
    public class DocumentValidationController : BaseController
    {

        private readonly IDocumentValidationService _service;

        public DocumentValidationController(IDocumentValidationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém uma lista de Documentos pendentes de aprovação do usuário da sessão.
        /// </summary>
        /// <response code="200">Retorna uma lista de documentos pendentes de aprovação do usuário da sessão.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListDocumentValidationByValidator")]
        public async Task<IActionResult> GetListDocumentValidationByValidatorAsync()
        {

            var ret = await _service.GetListDocumentValidationByValidatorAsync(ssn);

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
        /// Obtém uma lista de Documentos retornados para edição do usuário da sessão.
        /// </summary>
        /// <response code="200">Retorna uma lista de documentos retornados para edição do usuário da sessão.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListDocumentValidationToEdit")]
        public async Task<IActionResult> GetListDocumentValidationToEditAsync()
        {

            var ret = await _service.GetListDocumentValidationToEditAsync(ssn);

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
