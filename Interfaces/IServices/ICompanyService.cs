using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface ICompanyService
    {

        public Task<Retorno<CompanyResponseDTO>> GetCompanyByIdAsync(int companyId, UserSession ssn);
        public Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetCompanyAsync();

    }
}
