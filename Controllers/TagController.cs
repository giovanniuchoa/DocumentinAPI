using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.Tag;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Tag")]
    [Authorize]
    public class TagController : BaseController
    {

        private readonly ITagService _service;

        public TagController(ITagService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém uma Tag pelo identificador.
        /// </summary>
        /// <response code="200">Retorna a Tag correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetTagById/{tagId}")]
        [ProducesResponseType(typeof(Retorno<TagResponseDTO>), 200)]
        public async Task<IActionResult> GetTagByIdAsync(int tagId)
        {

            var ret = await _service.GetTagByIdAsync(tagId, ssn);

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
        /// Obtém uma lista das Tags da empresa do usuário.
        /// </summary>
        /// <response code="200">Retorna uma lista de Tags.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListTag")]
        [ProducesResponseType(typeof(Retorno<List<TagResponseDTO>>), 200)]
        public async Task<IActionResult> GetListTagAsync()
        {

            var ret = await _service.GetListTagAsync(ssn);

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
        /// Cadastra uma Tag.
        /// </summary>
        /// <response code="200">Retorna a Tag cadastrada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddTag")]
        [ProducesResponseType(typeof(Retorno<TagResponseDTO>), 200)]
        public async Task<IActionResult> AddTagAsync([FromBody] TagRequestDTO dto)
        {

            var ret = await _service.AddTagAsync(dto, ssn);

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
        /// Atualiza uma Tag.
        /// </summary>
        /// <response code="200">Retorna a Tag atualizada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdateTag")]
        [ProducesResponseType(typeof(Retorno<TagResponseDTO>), 200)]
        public async Task<IActionResult> UpdateTagAsync([FromBody] TagRequestDTO dto)
        {

            var ret = await _service.UpdateTagAsync(dto, ssn);

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
        /// Atualiza o status de uma Tag (IsActive).
        /// </summary>
        /// <response code="200">Retorna a Tag atualizada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("ToogleStatusTag/{tagId}")]
        [ProducesResponseType(typeof(Retorno<TagResponseDTO>), 200)]
        public async Task<IActionResult> ToogleStatusTagAsync(int tagId)
        {

            var ret = await _service.ToogleStatusTagAsync(tagId, ssn);

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
        /// Obtém uma lista dos documentos de uma Tag.
        /// </summary>
        /// <response code="200">Retorna uma lista de Documentos.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetDocumentXTagByTagId")]
        [ProducesResponseType(typeof(Retorno<List<DocumentResponseDTO>>), 200)]
        public async Task<IActionResult> GetDocumentXTagByTagIdAsync(int idTag)
        {

            var ret = await _service.GetDocumentXTagByTagIdAsync(idTag, ssn);

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
        /// Obtém uma lista das Tags de um Documento.
        /// </summary>
        /// <response code="200">Retorna uma lista de Tags.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetDocumentXTagByDocumentId")]
        [ProducesResponseType(typeof(Retorno<List<TagResponseDTO>>), 200)]
        public async Task<IActionResult> GetDocumentXTagByDocumentIdAsync(int idDocument)
        {

            var ret = await _service.GetDocumentXTagByDocumentIdAsync(idDocument, ssn);

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
        /// Cadastra um vínculo Documento x Tag.
        /// </summary>
        /// <response code="200">Retorna o vínculo cadastrado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddDocumentXTag")]
        [ProducesResponseType(typeof(Retorno<DocumentXTagResponseDTO>), 200)]
        public async Task<IActionResult> AddDocumentXTagAsync([FromBody] DocumentXTagRequestDTO dto)
        {

            var ret = await _service.AddDocumentXTagAsync(dto, ssn);

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
        /// Remove um vínculo Documento x Tag.
        /// </summary>
        /// <response code="200">Retorna uma lista dos Documentos restantes vinculados a Tag.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("DeleteDocumentXTag")]
        [ProducesResponseType(typeof(Retorno<List<TagResponseDTO>>), 200)]
        public async Task<IActionResult> DeleteDocumentXTagAsync([FromBody] DocumentXTagRequestDTO dto)
        {

            var ret = await _service.DeleteDocumentXTagAsync(dto, ssn);

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
