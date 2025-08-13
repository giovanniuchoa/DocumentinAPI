using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.DTOs.Template;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class TemplateService : ITemplateService
    {

        private readonly ITemplateRepository _repository;

        public TemplateService(ITemplateRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<TemplateResponseDTO>> AddTemplateAsync(TemplateRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TemplateResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.AddTemplateAsync(dto, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<TemplateResponseDTO>>> GetListTemplateAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<TemplateResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.GetListTemplateAsync(ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TemplateResponseDTO>> GetTemplateByIdAsync(int templateId, UserClaimDTO ssn)
        {

            Retorno<TemplateResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GetTemplateByIdAsync(templateId, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TemplateResponseDTO>> ToggleStatusTemplateAsync(int templateId, UserClaimDTO ssn)
        {

            Retorno<TemplateResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.ToggleStatusTemplateAsync(templateId, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TemplateResponseDTO>> UpdateTemplateAsync(TemplateRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TemplateResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.UpdateTemplateAsync(dto, ssn);
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
