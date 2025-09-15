using DocumentinAPI.Domain.DTOs.Import;
using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Import")]
    [Authorize]
    public class ImportController : BaseController
    {

        private readonly IImportService _service;

        public ImportController(IImportService service)
        {
            _service = service;
        }

        /// <summary>
        /// Importa um arquivo pdf e grava como um documento markdown no banco.
        /// </summary>
        /// <response code="200">Retorna o documento salvo.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("ImportDocumentPdf")]
        public async Task<IActionResult> ImportDocumentAsync([FromForm] ImportRequestDTO dto)
        {

            var ret = await _service.ImportDocumentAsync(dto, ssn);

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
