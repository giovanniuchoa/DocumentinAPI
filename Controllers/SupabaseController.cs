using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace DocumentinAPI.Controllers
{

    [Route("Supabase")]
    public class SupabaseController : BaseController
    {

        private readonly ISupabaseService _service;

        public SupabaseController(ISupabaseService service)
        {
            _service = service;
        }

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
