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

                var taskDB = await _context.Tasks
                    .Where(t => t.TaskId == dto.TaskId)
                    .FirstOrDefaultAsync();

                if (taskDB != null)
                {
                    throw new Exception("taskAlreadyExists");
                }

                taskDB = dto.Adapt<Domain.Models.Task>();

                taskDB.UserId = ssn.UserId;
                taskDB.CreatedAt = DateTime.Now;
                taskDB.UpdatedAt = DateTime.Now;
                taskDB.IsActive = true;

                await _context.Tasks.AddAsync(taskDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = taskDB.Adapt<TaskResponseDTO>();
                oRetorno.SetSucesso();

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

                var taskDB = await _context.Tasks
                    .Include(t => t.User)
                    .Where(t => t.TaskId == dto.TaskId
                        && t.User.CompanyId == ssn.CompanyId
                        && t.IsActive == true)
                    .FirstOrDefaultAsync();

                if (taskDB == null)
                {
                    throw new Exception("taskNotFound");
                }

                taskDB.Title = dto.Title;
                taskDB.Description = dto.Description;
                taskDB.DueDate = dto.DueDate;
                taskDB.Priority = dto.Priority;
                taskDB.Status = dto.Status;
                taskDB.AssigneeId = dto.AssigneeId;
                taskDB.ParentTaskId = dto.ParentTaskId;
                taskDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = taskDB.Adapt<TaskResponseDTO>();
                oRetorno.SetSucesso();

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

                var taskDB = await _context.Tasks
                    .Include(t => t.User)
                    .Where(t => t.TaskId == taskId
                        && t.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (taskDB == null)
                {
                    throw new Exception("taskNotFound");
                }
                
                taskDB.IsActive = !taskDB.IsActive;
                taskDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = taskDB.Adapt<TaskResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;


        }
    }
}
