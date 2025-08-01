using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Services
{
    public class TaskService : ITaskService
    {

        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<TaskResponseDTO>> GetTaskByIdAsync(int taskId, UserClaimDTO ssn)
        {

            Retorno<TaskResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GetTaskByIdAsync(taskId, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<ICollection<TaskResponseDTO>>> GetListTaskAsync(UserClaimDTO ssn)
        {

            Retorno<ICollection<TaskResponseDTO>> oRetorno = new();

            try {

                var ret = await _repository.GetListTaskAsync(ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TaskResponseDTO>> AddTaskAsync(TaskRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TaskResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.AddTaskAsync(dto, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TaskResponseDTO>> UpdateTaskAsync(TaskRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TaskResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.UpdateTaskAsync(dto, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TaskResponseDTO>> ToogleStatusTaskAsync(int taskId, UserClaimDTO ssn)
        {

            Retorno<TaskResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.ToogleStatusTaskAsync(taskId, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

    }
}
