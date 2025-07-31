using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ICompanyRepository
    {

        public Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetListCompanyAsync(UserClaimDTO ssn);
        public Task<Retorno<CompanyResponseDTO>> GetCompanyByIdAsync(int companyId, UserClaimDTO ssn);        
        public Task<Retorno<CompanyResponseDTO>> AddCompanyAsync(CompanyRequestDTO company, UserClaimDTO ssn);
        public Task<Retorno<CompanyResponseDTO>> UpdateCompanyAsync(CompanyRequestDTO company, UserClaimDTO ssn);
        public Task<Retorno<CompanyResponseDTO>> ToggleStatusCompanyAsync(int companyId, UserClaimDTO ssn);

    }
}
