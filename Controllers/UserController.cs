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

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var retorno = await _service.AddUserAsync(dto, ssn);

                if (retorno.Erro)
                {

                    if (retorno.Mensagem == "noPermission")
                    {
                        return Forbid(retorno.Mensagem);
                    }
                    else
                    {
                        return BadRequest(retorno);
                    }
                       
                }
                else
                {
                    return Ok(retorno);
                }   
            
            }
            else
            {
                return Forbid("noPermission");
            }

        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserRequestDTO dto)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var retorno = await _service.UpdateUserAsync(dto, ssn);

                if (retorno.Erro)
                {

                    if (retorno.Mensagem == "noPermission")
                    {
                        return Forbid(retorno.Mensagem);
                    }
                    else
                    {
                        return BadRequest(retorno);
                    }

                }
                else
                {
                    return Ok(retorno);
                }
            }
            else
            {
                return Forbid("noPermission");
            }

        }

        [HttpPut("ToggleStatusUser/{userId}")]
        public async Task<IActionResult> ToggleStatusUserAsync(int userId)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var retorno = await _service.ToggleStatusUserAsync(userId, ssn);

                if (retorno.Erro)
                {

                    if (retorno.Mensagem == "noPermission")
                    {
                        return Forbid(retorno.Mensagem);
                    }
                    else
                    {
                        return BadRequest(retorno);
                    }

                }
                else
                {
                    return Ok(retorno);
                }
            }
            else
            {
                return Forbid("noPermission");
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

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var retorno = await _service.AddUserXGroupAsync(model, ssn);

                if (retorno.Erro)
                {

                    if (retorno.Mensagem == "noPermission")
                    {
                        return Forbid(retorno.Mensagem);
                    }
                    else
                    {
                        return BadRequest(retorno);
                    }

                }
                else
                {
                    return Ok(retorno);
                }
            }
            else
            {
                return Forbid("noPermission");
            }

        }

        [HttpDelete("DeleteUserXGroup")]
        public async Task<IActionResult> DeleteUserXGroupAsync([FromBody] UserXGroupRequestDTO model)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var retorno = await _service.DeleteUserXGroupAsync(model, ssn);

                if (retorno.Erro)
                {

                    if (retorno.Mensagem == "noPermission")
                    {
                        return Forbid(retorno.Mensagem);
                    }
                    else
                    {
                        return BadRequest(retorno);
                    }

                }
                else
                {
                    return Ok(retorno);
                }
            }
            else
            {
                return Forbid("noPermission");
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

        [HttpPost("ValidateTokenPasswordRecovery")]
        [AllowAnonymous]
        public async Task<IActionResult> ValidateTokenPasswordRecoveryAsync([FromBody] ValidatePasswordRecoveryRequestDTO model)
        {

            var retorno = await _service.ValidateTokenPasswordRecoveryAsync(model);

            if (retorno.Erro)
            {
                return BadRequest(retorno);
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpPut("UpdatePasswordRecovery")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePasswordRecoveryAsync([FromBody] UpdatePasswordRecoveryRequestDTO model)
        {

            var retorno = await _service.UpdatePasswordRecoveryAsync(model);

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
