using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Document")]
    [Authorize]
    public class DocumentController : BaseController
    {

        private readonly IDocumentService _service;

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém um Documento pelo identificador.
        /// </summary>
        /// <response code="200">Retorna o documento correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetDocumentById/{documentId}")]
        [ProducesResponseType(typeof(Retorno<DocumentResponseDTO>), 200)]
        public async Task<IActionResult> GetDocumentByIdAsync(int documentId)
        {

            var ret = await _service.GetDocumentByIdAsync(documentId, ssn);

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
        /// Obtém uma lista de Documentos.
        /// </summary>
        /// <response code="200">Retorna uma lista de documentos.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListDocument")]
        [ProducesResponseType(typeof(Retorno<List<DocumentResponseDTO>>), 200)]
        public async Task<IActionResult> GetListDocumentAsync()
        {
            var ret = await _service.GetListDocumentAsync(ssn);
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
        /// Cadastra um Documento.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta do documento cadastrado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddDocument")]
        [ProducesResponseType(typeof(Retorno<DocumentResponseDTO>), 200)]
        public async Task<IActionResult> AddDocumentAsync([FromBody] DocumentRequestDTO document)
        {

            var ret = await _service.AddDocumentAsync(document, ssn);

            if (ret.Erro)
            {

                if (ret.Mensagem == "noPermission")
                {
                    return Forbid(ret.Mensagem);
                }
                else
                {
                    return BadRequest(ret);
                }

            }
            else
            {
                return Ok(ret);
            }

        }

        /// <summary>
        /// Atualiza um Documento.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta do documento atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdateDocument")]
        [ProducesResponseType(typeof(Retorno<DocumentResponseDTO>), 200)]
        public async Task<IActionResult> UpdateDocumentAsync([FromBody] DocumentRequestDTO document)
        {

            var ret = await _service.UpdateDocumentAsync(document, ssn);

            if (ret.Erro)
            {

                if (ret.Mensagem == "noPermission")
                {
                    return Forbid(ret.Mensagem);
                }
                else
                {
                    return BadRequest(ret);
                }

            }
            else
            {
                return Ok(ret);
            }

        }

        /// <summary>
        /// Alterna o status (ativo/inativo) de um documento.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta do documento atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("ToogleStatusDocument/{documentId}")]
        [ProducesResponseType(typeof(Retorno<DocumentResponseDTO>), 200)]
        public async Task<IActionResult> ToogleStatusDocumentAsync(int documentId)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var ret = await _service.ToogleStatusDocumentAsync(documentId, ssn);

                if (ret.Erro)
                {

                    if (ret.Mensagem == "noPermission")
                    {
                        return Forbid(ret.Mensagem);
                    }
                    else
                    {
                        return BadRequest(ret);
                    }

                }
                else
                {
                    return Ok(ret);
                }
            }
            else
            {
                return Forbid("noPermission");
            }

        }

        [HttpGet("GetUserDocuments")]
        [ProducesResponseType(typeof(Retorno<List<DocumentResponseDTO>>), 200)]
        public async Task<IActionResult> GetUserDocumentsAsync()
        {
            var ret = await _service.GetUserDocumentsAsync(ssn);
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
