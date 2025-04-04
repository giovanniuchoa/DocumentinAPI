using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface ICompanyService
    {

        public Task<Retorno<CompanyResponseDTO>> GetCompanyByIdAsync(int companyId, UserSession ssn);
        public Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetCompanyAsync();
        public Task<Retorno<CompanyResponseDTO>> AddCompanyAsync(CompanyRequestDTO company, UserSession ssn);
        public Task<Retorno<CompanyResponseDTO>> UpdateCompanyAsync(CompanyRequestDTO company, UserSession ssn);

    }
}
