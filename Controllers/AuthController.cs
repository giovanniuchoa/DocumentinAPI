using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        /// <summary>
        /// Autentica um usuário e retorna um token de acesso.
        /// </summary>
        /// <response code="200">Retorna um token de acesso.</response>
        /// <response code="400">Se a autenticação falhou.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthRequestDTO model)
        {

            var ret = await _service.AuthenticateAsync(model);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }else
            {
                return Ok(ret);
            }

        }

    }
}
