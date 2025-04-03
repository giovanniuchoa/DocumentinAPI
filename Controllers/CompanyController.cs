using DocumentinAPI.Authentication;
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

    }
}
