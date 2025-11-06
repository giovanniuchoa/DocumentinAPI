using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Email;
using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {

        private readonly IEmailService _emailService;

        public TaskRepository(DBContext context, IEmailService emailService) : base(context)
        {
            _emailService = emailService;
        }

        public async Task<Retorno<TaskResponseDTO>> GetTaskByIdAsync(int taskId, UserClaimDTO ssn)
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

        public async Task<Retorno<ICollection<TaskResponseDTO>>> GetListTaskAsync(UserClaimDTO ssn)
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

        public async Task<Retorno<TaskResponseDTO>> AddTaskAsync(TaskRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TaskResponseDTO> oRetorno = new Retorno<TaskResponseDTO>();

            try
            {

                var taskDB = await _context.Tasks
                    .Include(t => t.Assignee)
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

                try
                {

                    var assignee = await _context.Users
                        .Where(u => u.UserId == dto.AssigneeId && u.IsActive)
                        .FirstOrDefaultAsync();

                    var dados = new TaskEmailTemplateDTO
                    {
                        AssigneeName = assignee.Name,
                        Title = taskDB.Title,
                        DueDate = taskDB.DueDate,
                        Description = taskDB.Description
                    };

                    _emailService.SendEmailNewTaskToAssignee(assignee.Email, dados);

                }
                catch (Exception)
                {
                    throw;
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

        public async Task<Retorno<TaskResponseDTO>> UpdateTaskAsync(TaskRequestDTO dto, UserClaimDTO ssn)
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

        public async Task<Retorno<TaskResponseDTO>> ToogleStatusTaskAsync(int taskId, UserClaimDTO ssn)
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
