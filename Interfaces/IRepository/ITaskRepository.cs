using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ITaskRepository
    {

        public Task<Retorno<TaskResponseDTO>> GetTaskByIdAsync(int taskId, UserSession ssn);
        public Task<Retorno<ICollection<TaskResponseDTO>>> GetListTaskAsync(UserSession ssn);
        public Task<Retorno<TaskResponseDTO>> AddTaskAsync(TaskRequestDTO dto, UserSession ssn);
        public Task<Retorno<TaskResponseDTO>> UpdateTaskAsync(TaskRequestDTO dto, UserSession ssn);
        public Task<Retorno<TaskResponseDTO>> ToogleStatusTaskAsync(int taskId, UserSession ssn);

    }
}
