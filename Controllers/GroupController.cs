using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Group")]
    [Authorize]
    public class GroupController : ControllerBase
    {

        private readonly IGroupService _service;

        public GroupController(IGroupService service)
        {
            _service = service;
        }

        [HttpGet("GetGroupById/{groupId}")]
        public async Task<IActionResult> GetGroupById(int groupId)
        {
            var ret = await _service.GetGroupByIdAsync(groupId, TokenService.GetClaimsData(HttpContext.User));

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
        public async Task<IActionResult> GetListGroup()
        {
            var ret = await _service.GetListGroupAsync(TokenService.GetClaimsData(HttpContext.User));

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
        public async Task<IActionResult> AddGroup([FromBody] GroupRequestDTO group)
        {
            var ret = await _service.AddGroupAsync(group, TokenService.GetClaimsData(HttpContext.User));

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }

        }

        [HttpPut("UpdateGroup")]
        public async Task<IActionResult> UpdateGroup([FromBody] GroupRequestDTO group)
        {
            var ret = await _service.UpdateGroupAsync(group, TokenService.GetClaimsData(HttpContext.User));

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }
        }

        [HttpPut("DeleteGroup/{groupId}")]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            var ret = await _service.DeleteGroupAsync(groupId, TokenService.GetClaimsData(HttpContext.User));

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
