using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.Models;
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

        public async Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetListCompanyAsync()
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
                    throw new Exception("notFound");
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

        public async Task<Retorno<CompanyResponseDTO>> AddCompanyAsync(CompanyRequestDTO company, UserSession ssn)
        {

            Retorno<CompanyResponseDTO> oRetorno = new();

            try
            {

                if (ssn.Profile != "1")
                {
                    throw new Exception("noPermission");
                }

                var empresaDB = company.Adapt<Company>();

                await _context.Companies.AddAsync(empresaDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = empresaDB.Adapt<CompanyResponseDTO>();
                oRetorno.SetSucesso();

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

                if (!("1,2").Contains(ssn.Profile)) /* Somente dev e adm podem alterar empresas */
                {
                    throw new Exception("noPermission");
                }

                var empresaDB = await _context.Companies
                    .Where(x => x.CompanyId == company.CompanyId)
                    .FirstOrDefaultAsync();

                if (empresaDB == null)
                {
                    throw new Exception("notFound");
                }

                empresaDB.Name = company.Name;
                empresaDB.Phone = company.Phone;
                empresaDB.Adress = company.Adress;
                empresaDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = empresaDB.Adapt<CompanyResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<CompanyResponseDTO>> ToggleStatusCompanyAsync(int companyId, UserSession ssn)
        {

            Retorno<CompanyResponseDTO> oRetorno = new();

            try
            {

                if (ssn.Profile != "1")
                {
                    throw new Exception("noPermission");
                }

                var empresa = await _context.Companies
                    .Where(e => e.CompanyId == companyId)
                    .FirstOrDefaultAsync();

                empresa.IsActive = !empresa.IsActive;
                empresa.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = empresa.Adapt<CompanyResponseDTO>();
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
