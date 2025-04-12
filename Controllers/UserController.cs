using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("User")]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {

            var retorno = await _service.GetUserByIdAsync(userId, TokenService.GetClaimsData(HttpContext.User));

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpGet("GetListUser")]
        public async Task<IActionResult> GetListUser()
        {

            var retorno = await _service.GetListUserAsync(TokenService.GetClaimsData(HttpContext.User));

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }
        }

    }
}
