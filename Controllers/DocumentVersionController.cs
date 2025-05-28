using DocumentinAPI.Domain.DTOs.DocumentVersion;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("DocumentVersion")]
    [Authorize]
    public class DocumentVersionController : BaseController
    {

        private readonly IDocumentVersionService _service;

        public DocumentVersionController(IDocumentVersionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém uma versão de documento pelo identificador.
        /// </summary>
        /// <response code="200">Retorna a versão do documento correspondente ao identificador do documento.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetDocumentVersionById/{documentVersionId}")]
        public async Task<IActionResult> GetDocumentVersionByIdAsync(int documentVersionId)
        {

            var ret = await _service.GetDocumentVersionByIdAsync(documentVersionId, ssn);

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
        /// Obtém uma lista de versões do documento correspondente ao identificador.
        /// </summary>
        /// <response code="200">Retorna uma lista de versões do documento.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListDocumentVersionByDocumentId/{documentId}")]
        public async Task<IActionResult> GetDocumentVersionsByDocumentIdAsync(int documentId)
        {

            var ret = await _service.GetDocumentVersionsByDocumentIdAsync(documentId, ssn);

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
        /// Adiciona um comentario na versão do documento.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta da versão do documento atualizada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddCommentDocumentVersion")]
        public async Task<IActionResult> AddCommentDocumentVersionAsync([FromBody] DocumentVersionAddCommentRequestDTO dto)
        {

            var ret = await _service.AddCommentDocumentVersionAsync(dto, ssn);

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

        }
    }
