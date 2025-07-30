using DocumentinAPI.Domain.DTOs.Folder;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Folder")]
    [Authorize]
    public class FolderController : BaseController
    {

        private readonly IFolderService _service;

        public FolderController(IFolderService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém uma pasta pelo identificador.
        /// </summary>
        /// <response code="200">Retorna a pasta correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetFolderById/{folderId}")]
        public async Task<IActionResult> GetFolderByIdAsync(int folderId)
        {

            var ret = await _service.GetFolderByIdAsync(folderId, ssn);

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
        /// Obtém uma lista de pastas.
        /// </summary>
        /// <response code="200">Retorna uma lista de pastas.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListFolder")]
        public async Task<IActionResult> GetListFolderAsync()
        {

            var ret = await _service.GetListFolderAsync(ssn);

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
        /// Cadastra uma pasta.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta da pasta cadastrada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddFolder")]
        public async Task<IActionResult> AddFolderAsync([FromBody] FolderRequestDTO dto)
        {

            var ret = await _service.AddFolderAsync(dto, ssn);

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
        /// Atualiza uma pasta.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta da pasta atualizada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdateFolder")]
        public async Task<IActionResult> UpdateFolderAsync([FromBody] FolderRequestDTO dto)
        {

            var ret = await _service.UpdateFolderAsync(dto, ssn);

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
        /// Alterna o status (ativo/inativo) da pasta.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta da pasta atualizada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("ToogleStatusFolder/{folderId}")]
        public async Task<IActionResult> ToogleStatusFolderAsync(int folderId)
        {

            var ret = await _service.ToogleStatusFolderAsync(folderId, ssn);

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
