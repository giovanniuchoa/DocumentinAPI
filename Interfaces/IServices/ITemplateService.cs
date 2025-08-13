using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Template;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface ITemplateService
    {

        public Task<Retorno<TemplateResponseDTO>> GetTemplateByIdAsync(int templateId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<TemplateResponseDTO>>> GetListTemplateAsync(UserClaimDTO ssn);
        public Task<Retorno<TemplateResponseDTO>> AddTemplateAsync(TemplateRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<TemplateResponseDTO>> UpdateTemplateAsync(TemplateRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<TemplateResponseDTO>> ToggleStatusTemplateAsync(int templateId, UserClaimDTO ssn);

    }
}
