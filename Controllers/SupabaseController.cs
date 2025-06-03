using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace DocumentinAPI.Controllers
{

    [Route("Supabase")]
    [Authorize]
    public class SupabaseController : BaseController
    {

        private readonly ISupabaseService _service;

        public SupabaseController(ISupabaseService service)
        {
            _service = service;
        }

        /// <summary>
        /// Faz o Upload de uma imagem na nuvem e retorna sua URL.
        /// </summary>
        /// <response code="200">Retorna a URL da imagem salva.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImageAsync([FromForm] UploadImageRequestDTO dto)
        {

            var ret = await _service.UploadImageAsync(dto);

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
