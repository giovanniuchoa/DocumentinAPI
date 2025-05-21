using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {

        public TaskRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<TaskResponseDTO>> GetTaskByIdAsync(int taskId, UserSession ssn)
        {
            
            Retorno<TaskResponseDTO> oRetorno = new Retorno<TaskResponseDTO>();

            try
            {

                var taskDB = await _context.Tasks
                    .Include(t => t.User)
                    .Where(t => t.TaskId == taskId
                        && t.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (taskDB == null)
                {
                    throw new Exception("taskNotFound");
                }

                oRetorno.Objeto = taskDB.Adapt<TaskResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<ICollection<TaskResponseDTO>>> GetListTaskAsync(UserSession ssn)
        {

            Retorno<ICollection<TaskResponseDTO>> oRetorno = new Retorno<ICollection<TaskResponseDTO>>();

            try
            {

                var taskListDB = await _context.Tasks
                    .Include(t => t.User)
                    .Where(t => t.User.CompanyId == ssn.CompanyId)
                    .ToListAsync();

                oRetorno.Objeto = taskListDB.Adapt<List<TaskResponseDTO>>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;


        }

        public async Task<Retorno<TaskResponseDTO>> AddTaskAsync(TaskRequestDTO dto, UserSession ssn)
        {

            Retorno<TaskResponseDTO> oRetorno = new Retorno<TaskResponseDTO>();

            try
            {



            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;


        }

        public async Task<Retorno<TaskResponseDTO>> UpdateTaskAsync(TaskRequestDTO dto, UserSession ssn)
        {

            Retorno<TaskResponseDTO> oRetorno = new Retorno<TaskResponseDTO>();

            try
            {



            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;


        }

        public async Task<Retorno<TaskResponseDTO>> ToogleStatusTaskAsync(int taskId, UserSession ssn)
        {

            Retorno<TaskResponseDTO> oRetorno = new Retorno<TaskResponseDTO>();

            try
            {



            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;


        }
    }
}
