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

        /// <summary>
        /// Obtém uma tarefa pelo identificador.
        /// </summary>
        /// <response code="200">Retorna a tarefa correspondente ao identificador.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
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

        /// <summary>
        /// Obtém uma lista de tarefas.
        /// </summary>
        /// <response code="200">Retorna uma lista de tarefas.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
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

        /// <summary>
        /// Cadastra uma tarefa.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta da tarefa cadastrada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
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

        /// <summary>
        /// Atualiza uma tarefa.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta da tarefa atualizada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
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

        /// <summary>
        /// Alterna o status (ativo/inativo) da tarefa.
        /// </summary>
        /// <response code="200">Retorna o DTO de resposta da tarefa atualizada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="400">Se ocorrer algum erro inesperado.</response>
        /// <response code="500">Erro interno do servidor.</response>
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
