using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ICompanyRepository
    {

        public Task<Retorno<CompanyResponseDTO>> GetCompanyByIdAsync(int companyId, UserSession ssn);
        public Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetListCompanyAsync();
        public Task<Retorno<CompanyResponseDTO>> AddCompanyAsync(CompanyRequestDTO company, UserSession ssn);
        public Task<Retorno<CompanyResponseDTO>> UpdateCompanyAsync(CompanyRequestDTO company, UserSession ssn);
        public Task<Retorno<CompanyResponseDTO>> DeleteCompanyAsync(int companyId, UserSession ssn);

    }
}
