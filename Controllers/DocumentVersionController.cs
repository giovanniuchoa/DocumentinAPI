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

            //[HttpPost("AddDocumentVersion")]
            //public async Task<IActionResult> AddDocumentVersion([FromBody] DocumentVersionRequestDTO dto)
            //{

            //    if (("1,2").Contains(ssn.Profile.ToString()))
            //    {

            //        var ret = await _service.AddDocumentVersionAsync(dto, ssn);

            //        if (ret.Erro)
            //        {

            //            if (ret.Mensagem == "noPermission")
            //            {
            //                return Forbid(ret.Mensagem);
            //            }
            //            else
            //            {
            //                return BadRequest(ret);
            //            }

            //        }
            //        else
            //        {
            //            return Ok(ret);
            //        }
            //    }
            //    else
            //    {
            //        return Forbid("noPermission");
            //    }

            //}

        }
    }
