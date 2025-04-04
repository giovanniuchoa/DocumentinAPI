using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using System.Collections.Generic;

namespace DocumentinAPI.Services
{
    public class CompanyService : ICompanyService
    {

        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetCompanyAsync()
        {

            Retorno<IEnumerable<CompanyResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.GetCompanyAsync();

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<CompanyResponseDTO>> GetCompanyByIdAsync(int companyId, UserSession ssn)
        {

            Retorno<CompanyResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GetCompanyByIdAsync(companyId, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<CompanyResponseDTO>> AddCompanyAsync(CompanyRequestDTO company, UserSession ssn)
        {

            Retorno<CompanyResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.AddCompanyAsync(company, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<CompanyResponseDTO>> UpdateCompanyAsync(CompanyRequestDTO company, UserSession ssn)
        {

            Retorno<CompanyResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.UpdateCompanyAsync(company, ssn);

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
