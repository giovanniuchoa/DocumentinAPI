using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.DTOs.PasswordRecovery;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.DTOs.UserXGroup;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("User")]
    [Authorize]
    public class UserController : BaseController
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(int userId)
        {

            var retorno = await _service.GetUserByIdAsync(userId, ssn);

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

            var retorno = await _service.GetListUserAsync(ssn);

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

            var retorno = await _service.AddUserAsync(dto, ssn);

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

            var retorno = await _service.UpdateUserAsync(dto, ssn);

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpPut("ToggleStatusUser/{userId}")]
        public async Task<IActionResult> ToggleStatusUserAsync(int userId)
        {

            var retorno = await _service.ToggleStatusUserAsync(userId, ssn);

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpGet("GetListGroupByUser/{userId}")]
        public async Task<IActionResult> GetListUserXGroupByUserAsync(int userId)
        {

            var retorno = await _service.GetListUserXGroupByUserAsync(userId, ssn);

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpPost("AddUserXGroup")]
        public async Task<IActionResult> AddUserXGroupAsync([FromBody] UserXGroupRequestDTO model)
        {

            var retorno = await _service.AddUserXGroupAsync(model, ssn);

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpDelete("DeleteUserXGroup")]
        public async Task<IActionResult> DeleteUserXGroupAsync([FromBody] UserXGroupRequestDTO model)
        {

            var retorno = await _service.DeleteUserXGroupAsync(model, ssn);

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpPost("RequestPasswordRecovery")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestPasswordRecoveryAsyncAsync([FromBody] PasswordRecoveryRequestDTO model)
        {

            var retorno = await _service.RequestPasswordRecoveryAsync(model);

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
