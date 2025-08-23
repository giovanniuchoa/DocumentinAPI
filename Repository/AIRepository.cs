using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.LogAPIRequest;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using System.Reactive.Threading.Tasks;

namespace DocumentinAPI.Repository
{
    public class AIRepository : BaseRepository, IAIRepository
    {

        public AIRepository(DBContext context) : base(context)
        {
        }

        public async System.Threading.Tasks.Task LogAIRequestAsync(LogAIRequestDTO dto, UserClaimDTO ssn)
        {           

            try
            {

                var logDB = dto.Adapt<LogAIRequest>();

                logDB.UserId = ssn.UserId;
                logDB.CreatedAt = DateTime.UtcNow;

                await _context.LogAIRequests.AddAsync(logDB);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
