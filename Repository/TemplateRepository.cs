using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Template;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class TemplateRepository : BaseRepository, ITemplateRepository
    {

        public TemplateRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<TemplateResponseDTO>> AddTemplateAsync(TemplateRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TemplateResponseDTO> oRetorno = new Retorno<TemplateResponseDTO>();

            try
            {

                var templateDB = dto.Adapt<Template>();

                templateDB.IsActive = true;
                templateDB.CreatedAt = DateTime.Now;
                templateDB.UpdatedAt = DateTime.Now;

                await _context.Templates.AddAsync(templateDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = templateDB.Adapt<TemplateResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<TemplateResponseDTO>>> GetListTemplateAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<TemplateResponseDTO>> oRetorno = new Retorno<IEnumerable<TemplateResponseDTO>>();

            try
            {

                var templateDB = await _context.Templates
                    .ToListAsync();

                oRetorno.Objeto = templateDB.Adapt<List<TemplateResponseDTO>>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TemplateResponseDTO>> GetTemplateByIdAsync(int templateId, UserClaimDTO ssn)
        {
            
            Retorno<TemplateResponseDTO> oRetorno = new Retorno<TemplateResponseDTO>();

            try
            {

                var templateDB = await _context.Templates
                    .Where(t => t.TemplateId == templateId)
                    .FirstOrDefaultAsync();

                oRetorno.Objeto = templateDB.Adapt<TemplateResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TemplateResponseDTO>> ToggleStatusTemplateAsync(int templateId, UserClaimDTO ssn)
        {

            Retorno<TemplateResponseDTO> oRetorno = new Retorno<TemplateResponseDTO>();

            try
            {

                var templateDB = await _context.Templates
                    .Where(t => t.TemplateId == templateId)
                    .FirstOrDefaultAsync();

                if (templateDB == null)
                {
                    throw new Exception("templateNotFound");
                }

                templateDB.IsActive = !templateDB.IsActive;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = templateDB.Adapt<TemplateResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TemplateResponseDTO>> UpdateTemplateAsync(TemplateRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TemplateResponseDTO> oRetorno = new Retorno<TemplateResponseDTO>();

            try
            {

                var templateDB = await _context.Templates
                    .Where(t => t.TemplateId == dto.TemplateId)
                    .FirstOrDefaultAsync();

                if (templateDB == null)
                {
                    throw new Exception("templateNotFound");
                }

                templateDB.Name = dto.Name;
                templateDB.Content = dto.Content;
                templateDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = templateDB.Adapt<TemplateResponseDTO>();
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
