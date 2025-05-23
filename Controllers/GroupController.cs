﻿using DocumentinAPI.Authentication;
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

    }
}
