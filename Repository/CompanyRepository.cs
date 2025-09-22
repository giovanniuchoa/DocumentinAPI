using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;
using DocumentinAPI.Domain.DTOs.Auth;
using System.Collections.Generic;

namespace DocumentinAPI.Repository
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {

        public CompanyRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<IEnumerable<CompanyResponseDTO>>> GetListCompanyAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<CompanyResponseDTO>> oRetorno = new();

            try
            {

                var empresaDB = await _context.Companies
                    .Where(c => !c.IsInternal)
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

        public async Task<Retorno<CompanyResponseDTO>> GetCompanyByIdAsync(int companyId, UserClaimDTO ssn)
        {

            Retorno<CompanyResponseDTO> oRetorno = new();

            try
            {

                var empresaDB = await _context.Companies
                    .Where(x => x.CompanyId == companyId
                        && x.CompanyId == ssn.CompanyId)
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

        public async Task<Retorno<CompanyResponseDTO>> AddCompanyAsync(CompanyRequestDTO company, UserClaimDTO ssn)
        {

            Retorno<CompanyResponseDTO> oRetorno = new();

            try
            {

                var empresaDB = await _context.Companies
                    .Where(x => x.TaxId == company.TaxId)
                    .FirstOrDefaultAsync();

                if (empresaDB != null)
                {
                    throw new Exception("alreadyExistsTaxId");
                }

                empresaDB = company.Adapt<Company>();

                empresaDB.IsInternal = false;
                empresaDB.CreatedAt = DateTime.Now;
                empresaDB.UpdatedAt = DateTime.Now;
                empresaDB.IsActive = true;

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

        public async Task<Retorno<CompanyResponseDTO>> UpdateCompanyAsync(CompanyRequestDTO company, UserClaimDTO ssn)
        {

            Retorno<CompanyResponseDTO> oRetorno = new();

            try
            {

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
                empresaDB.TaxId = company.TaxId;
                empresaDB.Phone = company.Phone;
                empresaDB.Email = company.Email;
                empresaDB.ZipCode = company.ZipCode;
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

        public async Task<Retorno<CompanyResponseDTO>> ToggleStatusCompanyAsync(int companyId, UserClaimDTO ssn)
        {

            Retorno<CompanyResponseDTO> oRetorno = new();

            try
            {

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
