using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Task")]
    [Authorize]
    public class TaskController : BaseController
    {

        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet("GetTaskById/{taskId}")]
        public async Task<IActionResult> GetTaskByIdAsync(int taskId)
        {

            var ret = await _service.GetTaskByIdAsync(taskId, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }

        }

        [HttpGet("GetListTask")]
        public async Task<IActionResult> GetListTaskAsync()
        {

            var ret = await _service.GetListTaskAsync(ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }

        }

        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTaskAsync([FromBody] TaskRequestDTO dto)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var ret = await _service.AddTaskAsync(dto, ssn);

                if (ret.Erro == true)
                {
                    return BadRequest(ret);
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

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTaskAsync([FromBody] TaskRequestDTO dto)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var ret = await _service.UpdateTaskAsync(dto, ssn);

                if (ret.Erro == true)
                {
                    return BadRequest(ret);
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

        [HttpPut("ToogleStatusTask/{taskId}")]
        public async Task<IActionResult> ToogleStatusTaskAsync(int taskId)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var ret = await _service.ToogleStatusTaskAsync(taskId, ssn);

                if (ret.Erro == true)
                {
                    return BadRequest(ret);
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

    }
}
