using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Comment;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Comment")]
    [Authorize]
    public class CommentController : BaseController
    {

        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém um comentário pelo identificador.
        /// </summary>
        /// <response code="200">Retorna o comentário correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetCommentById/{commentId}")]
        [ProducesResponseType(typeof(Retorno<CommentResponseDTO>), 200)]
        public async Task<IActionResult> GetCommentByIdAsync(int commentId)
        {

            var ret = await _service.GetCommentByIdAsync(commentId, ssn);

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
        /// Obtém os comentários da empresa do usuário.
        /// </summary>
        /// <response code="200">Retorna uma lista de comentários.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListComment")]
        [ProducesResponseType(typeof(Retorno<List<CommentResponseDTO>>), 200)]
        public async Task<IActionResult> GetListCommentAsync()
        {

            var ret = await _service.GetListCommentAsync(ssn);

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
        /// Obtém os comentários de um documento.
        /// </summary>
        /// <response code="200">Retorna uma lista de comentários correspondente ao identificador do documento.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListCommentByDocumentId/{documentId}")]
        [ProducesResponseType(typeof(Retorno<List<CommentResponseDTO>>), 200)]
        public async Task<IActionResult> GetListCommentByDocumentIdAsync(int documentId)
        {

            var ret = await _service.GetListCommentByDocumentIdAsync(documentId, ssn);

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
        /// Cadastra um comentário.
        /// </summary>
        /// <response code="200">Retorna o comentário adicionado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddComment")]
        [ProducesResponseType(typeof(Retorno<CommentResponseDTO>), 200)]
        public async Task<IActionResult> AddCommentAsync([FromBody] CommentRequestDTO dto)
        {

            var ret = await _service.AddCommentAsync(dto, ssn);

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
        /// Atualiza um comentário.
        /// </summary>
        /// <response code="200">Retorna o comentário atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdateComment")]
        [ProducesResponseType(typeof(Retorno<CommentResponseDTO>), 200)]
        public async Task<IActionResult> UpdateCommentAsync([FromBody] CommentRequestDTO dto)
        {

            var ret = await _service.UpdateCommentAsync(dto, ssn);

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
        /// Atualiza o status de um comentário (IsActive).
        /// </summary>
        /// <response code="200">Retorna o comentário atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("ToogleStatusComment/{commentId}")]
        [ProducesResponseType(typeof(Retorno<CommentResponseDTO>), 200)]
        public async Task<IActionResult> ToogleStatusCommentAsync(int commentId)
        {

            var ret = await _service.ToogleStatusCommentAsync(commentId, ssn);

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
