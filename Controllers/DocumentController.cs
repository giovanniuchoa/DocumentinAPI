using DocumentinAPI.Domain.DTOs.Document;
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

        [HttpGet("GetDocumentById/{documentId}")]
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

        [HttpGet("GetListDocument")]
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

        [HttpPost("AddDocument")]
        public async Task<IActionResult> AddDocumentAsync([FromBody] DocumentRequestDTO document)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
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
            else
            {
                return Forbid("noPermission");
            }

        }

        [HttpPut("UpdateDocument")]
        public async Task<IActionResult> UpdateDocumentAsync([FromBody] DocumentRequestDTO document)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
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
            else
            {
                return Forbid("noPermission");
            }

        }

        [HttpPut("ToogleStatusDocument/{documentId}")]
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

    }
}
