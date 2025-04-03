using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ICompanyRepository
    {

        public Task<Retorno<CompanyResponseDTO>> GetCompanyByIdAsync(int companyId, UserSession ssn);
        public Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetCompanyAsync();

    }
}
