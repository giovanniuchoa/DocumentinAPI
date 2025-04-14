using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.DTOs.User;
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
        public async Task<IActionResult> GetUserByIdAsync(int userId)
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
        public async Task<IActionResult> GetListUserAsync()
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

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserRequestDTO dto)
        {

            var retorno = await _service.AddUserAsync(dto, TokenService.GetClaimsData(HttpContext.User));

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserRequestDTO dto)
        {

            var retorno = await _service.UpdateUserAsync(dto, TokenService.GetClaimsData(HttpContext.User));

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpPut("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {

            var retorno = await _service.DeleteUserAsync(userId, TokenService.GetClaimsData(HttpContext.User));

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
