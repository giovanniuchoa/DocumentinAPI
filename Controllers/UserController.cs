using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.DTOs.DocumentVersion;
using DocumentinAPI.Domain.DTOs.Group;
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

        /// <summary>
        /// Obtém um Usuário pelo identificador.
        /// </summary>
        /// <response code="200">Retorna o usuário correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetUserById/{userId}")]
        [ProducesResponseType(typeof(Retorno<UserResponseDTO>), 200)]
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

        /// <summary>
        /// Obtém uma lista de Usuários.
        /// </summary>
        /// <response code="200">Retorna uma lista de usuário.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListUser")]
        [ProducesResponseType(typeof(Retorno<List<UserResponseDTO>>), 200)]
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

        /// <summary>
        /// Cadastra um Usuário.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta do usuário cadastrado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddUser")]
        [ProducesResponseType(typeof(Retorno<UserResponseDTO>), 200)]
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

        /// <summary>
        /// Atualiza um Usuário.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta do usuário atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdateUser")]
        [ProducesResponseType(typeof(Retorno<UserResponseDTO>), 200)]
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

        /// <summary>
        /// Alterna o status (ativo/inativo) de um Usuário.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta do usuário atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("ToggleStatusUser/{userId}")]
        [ProducesResponseType(typeof(Retorno<UserResponseDTO>), 200)]
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

        /// <summary>
        /// Obtém uma lista de grupos vinculados ao usuário correspondente ao identificador.
        /// </summary>
        /// <response code="200">Retorna uma lista de grupos vinculados ao usuário correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListGroupByUser/{userId}")]
        [ProducesResponseType(typeof(Retorno<List<GroupResponseDTO>>), 200)]
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

        /// <summary>
        /// Vincula um Usuário à um Grupo.
        /// </summary>
        /// <response code="200">Retorna uma lista de grupos vinculados ao usuário.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddUserXGroup")]
        [ProducesResponseType(typeof(Retorno<List<GroupResponseDTO>>), 200)]
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

        /// <summary>
        /// Desvincula um Usuário de um Grupo.
        /// </summary>
        /// <response code="200">Retorna uma lista de grupos vinculados ao usuário.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("DeleteUserXGroup")]
        [ProducesResponseType(typeof(Retorno<List<GroupResponseDTO>>), 200)]
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

        /// <summary>
        /// Envia token de recuperação de senha ao e-mail correspondente.
        /// </summary>
        /// <response code="200">Retorna DTO de recuperação de senha cadastrada.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("RequestPasswordRecovery")]
        [ProducesResponseType(typeof(Retorno<PasswordRecoveryResponseDTO>), 200)]
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

        /// <summary>
        /// Valida token enviado por e-mail.
        /// </summary>
        /// <response code="200">Retorna DTO com o token.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("ValidateTokenPasswordRecovery")]
        [ProducesResponseType(typeof(Retorno<ValidatePasswordRecoveryResponseDTO>), 200)]
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

        /// <summary>
        /// Atualiza a senha do usuário (caso validação do token tenha sucesso).
        /// </summary>
        /// <response code="200">Retorna DTO com o usuário atualizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdatePasswordRecovery")]
        [ProducesResponseType(typeof(Retorno<UserResponseDTO>), 200)]
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
