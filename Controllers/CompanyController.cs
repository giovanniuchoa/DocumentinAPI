using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{
    [Route("Company")]
    [Authorize]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet("GetCompanies")]
        public async Task<IActionResult> GetCompaniesAsync()
        {
            var ret = await _service.GetCompanyAsync();

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }

        }

        [HttpGet("GetCompaniesById/{companyId}")]
        public async Task<IActionResult> GetCompaniesByIdAsync(int companyId)
        {
            var ret = await _service.GetCompanyByIdAsync(companyId, TokenService.GetClaimsData(HttpContext.User));

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }

        }

        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCompanyAsync([FromBody] CompanyRequestDTO company)
        {

            var ret = await _service.AddCompanyAsync(company, TokenService.GetClaimsData(HttpContext.User));

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }

        }        
        
        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompanyAsync([FromBody] CompanyRequestDTO company)
        {

            var ret = await _service.UpdateCompanyAsync(company, TokenService.GetClaimsData(HttpContext.User));

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }

        }

    }
}
