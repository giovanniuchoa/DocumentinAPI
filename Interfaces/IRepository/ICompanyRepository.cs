﻿using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ICompanyRepository
    {

        public Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetListCompanyAsync(UserSession ssn);
        public Task<Retorno<CompanyResponseDTO>> GetCompanyByIdAsync(int companyId, UserSession ssn);        
        public Task<Retorno<CompanyResponseDTO>> AddCompanyAsync(CompanyRequestDTO company, UserSession ssn);
        public Task<Retorno<CompanyResponseDTO>> UpdateCompanyAsync(CompanyRequestDTO company, UserSession ssn);
        public Task<Retorno<CompanyResponseDTO>> ToggleStatusCompanyAsync(int companyId, UserSession ssn);

    }
}
