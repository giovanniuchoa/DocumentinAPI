using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Group")]
    [Authorize]
    public class GroupController : BaseController
    {

        private readonly IGroupService _service;

        public GroupController(IGroupService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém um Grupo pelo identificador.
        /// </summary>
        /// <response code="200">Retorna o grupo correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetGroupById/{groupId}")]
        public async Task<IActionResult> GetGroupByIdAsync(int groupId)
        {
            var ret = await _service.GetGroupByIdAsync(groupId, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        /// <summary>
        /// Obtém uma lista de Grupos.
        /// </summary>
        /// <response code="200">Retorna uma lista de grupos.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListGroup")]
        public async Task<IActionResult> GetListGroupAsync()
        {
            var ret = await _service.GetListGroupAsync(ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        /// <summary>
        /// Cadastra um Grupo.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta do grupo cadastrado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddGroup")]
        public async Task<IActionResult> AddGroupAsync([FromBody] GroupRequestDTO group)
        {
            
            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var ret = await _service.AddGroupAsync(group, ssn);

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

        /// <summary>
        /// Atualiza um Grupo.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta do grupo atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdateGroup")]
        public async Task<IActionResult> UpdateGroupAsync([FromBody] GroupRequestDTO group)
        {
            
            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var ret = await _service.UpdateGroupAsync(group, ssn);

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

        /// <summary>
        /// Alterna o status (ativo/inativo) de um grupo.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta do grupo atualizado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("ToggleStatusGroup/{groupId}")]
        public async Task<IActionResult> ToggleStatusGroupAsync(int groupId)
        {
            
            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var ret = await _service.ToggleStatusGroupAsync(groupId, ssn);

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

        /// <summary>
        /// Obtém uma lista de usuários vinculados ao grupo correspondente ao identificador.
        /// </summary>
        /// <response code="200">Retorna uma lista de usuários vinculados ao grupo correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListUserByGroup/{groupId}")]
        public async Task<IActionResult> GetListUserXGroupByGroupAsync(int groupId)
        {

            var ret = await _service.GetListUserXGroupByGroupAsync(groupId, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        /// <summary>
        /// Obtém uma lista de pastas vinculadas ao grupo correspondente ao identificador.
        /// </summary>
        /// <response code="200">Retorna uma lista de pastas vinculadas ao grupo correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetListFolderByGroup/{groupId}")]
        public async Task<IActionResult> GetListFolderXGroupByGroupAsync(int groupId)
        {

            var ret = await _service.GetListFolderXGroupByGroupAsync(groupId, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

    }
}
