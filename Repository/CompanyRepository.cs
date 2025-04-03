using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DocumentinAPI.Repository
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {

        public CompanyRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetCompanyAsync()
        {

            Retorno<IEnumerable<CompanyResponseDTO>> oRetorno = new();

            try
            {

                var empresaDB = await _context.Companies
                    .ToListAsync();

                var empresa = empresaDB.Adapt<List<CompanyResponseDTO>>();

                oRetorno.Objeto = empresa;

                oRetorno.SetSucesso();

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

                var empresaDB = await _context.Companies
                    .Where(x => x.CompanyId == companyId
                        && x.CompanyId.ToString() == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (empresaDB == null)
                {
                    throw new Exception("Company does not exists or user does not have access to it.");
                }

                oRetorno.Objeto = empresaDB.Adapt<CompanyResponseDTO>();
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
