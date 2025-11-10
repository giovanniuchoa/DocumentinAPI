using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.LogAPIRequest;
using DocumentinAPI.Domain.DTOs.OpenAIConfig;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Threading.Tasks;

namespace DocumentinAPI.Repository
{
    public class AIRepository : BaseRepository, IAIRepository
    {

        public AIRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<OpenAIConfigResponseDTO>> AddOpenAIConfigAsync(OpenAIConfigRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<OpenAIConfigResponseDTO> oRetorno = new();

            try
            {

                var configDB = dto.Adapt<OpenAIConfig>();

                configDB.CompanyId = ssn.CompanyId; 
                configDB.CreatedAt = DateTime.Now;
                configDB.UpdatedAt = DateTime.Now;

                await _context.OpenAIConfigs.AddAsync(configDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = configDB.Adapt<OpenAIConfigResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<OpenAIConfigResponseDTO>> GetOpenAIConfigByCompanyAsync(UserClaimDTO ssn)
        {

            Retorno<OpenAIConfigResponseDTO> oRetorno = new();

            try
            {

                var configDB = await _context.OpenAIConfigs
                    .Where(c => c.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (configDB == null)
                {
                    throw new Exception("openAiConfigNotFound");
                }

                oRetorno.Objeto = configDB.Adapt<OpenAIConfigResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async System.Threading.Tasks.Task LogAIRequestAsync(LogAIRequestDTO dto, UserClaimDTO ssn)
        {           

            var logDB = dto.Adapt<LogAIRequest>();

            logDB.UserId = ssn.UserId;
            logDB.CreatedAt = DateTime.UtcNow;

            await _context.LogAIRequests.AddAsync(logDB);

            await _context.SaveChangesAsync();

        }

        public async Task<Retorno<OpenAIConfigResponseDTO>> UpdateOpenAIConfigAsync(OpenAIConfigRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<OpenAIConfigResponseDTO> oRetorno = new();

            try
            {

                var configDB = await _context.OpenAIConfigs
                    .Where(c => c.OpenAIConfigId == dto.OpenAIConfigId
                        && c.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (configDB == null)
                {
                    throw new Exception("openAiConfigNotFound");
                }

                configDB.ApiKey = dto.ApiKey;
                configDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = configDB.Adapt<OpenAIConfigResponseDTO>();
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
