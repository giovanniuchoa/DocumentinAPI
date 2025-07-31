using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ITaskRepository
    {

        public Task<Retorno<TaskResponseDTO>> GetTaskByIdAsync(int taskId, UserClaimDTO ssn);
        public Task<Retorno<ICollection<TaskResponseDTO>>> GetListTaskAsync(UserClaimDTO ssn);
        public Task<Retorno<TaskResponseDTO>> AddTaskAsync(TaskRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<TaskResponseDTO>> UpdateTaskAsync(TaskRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<TaskResponseDTO>> ToogleStatusTaskAsync(int taskId, UserClaimDTO ssn);

    }
}
