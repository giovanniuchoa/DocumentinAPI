using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.DTOs.Company;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{
    [Route("Company")]
    [Authorize]
    public class CompanyController : BaseController
    {

        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet("GetCompaniesById/{companyId}")]
        public async Task<IActionResult> GetCompaniesByIdAsync(int companyId)
        {

            var ret = await _service.GetCompanyByIdAsync(companyId, ssn);

            if (ret.Erro == true)
            {
                return BadRequest(ret);
            }
            else
            {
                return Ok(ret);
            }

        }

        [HttpGet("GetListCompanies")]
        public async Task<IActionResult> GetListCompaniesAsync()
        {
            
            if (ssn.Profile == 1)
            {

                var ret = await _service.GetListCompanyAsync(ssn);

                if (ret.Erro)
                {

                    if (ret.Mensagem == "noPermission")
                    {
                        return Forbid(ret.Mensagem);
                    }
                    else
                    {
                        return BadRequest(ret);
                    }

                }
                else
                {
                    return Ok(ret);
                }

            }
            else
            {
                return Forbid("noPermission");
            }

        }

        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCompanyAsync([FromBody] CompanyRequestDTO company)
        {

            if (ssn.Profile == 1)
            {

                var ret = await _service.AddCompanyAsync(company, ssn);

                if (ret.Erro)
                {

                    if (ret.Mensagem == "noPermission")
                    {
                        return Forbid(ret.Mensagem);
                    }
                    else
                    {
                        return BadRequest(ret);
                    }

                }
                else
                {
                    return Ok(ret);
                }

            }
            else
            {
                return Forbid("noPermission");
            }

        }        
        
        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompanyAsync([FromBody] CompanyRequestDTO company)
        {

            if (("1,2").Contains(ssn.Profile.ToString()))
            {

                var ret = await _service.UpdateCompanyAsync(company, ssn);

                if (ret.Erro)
                {

                    if (ret.Mensagem == "noPermission")
                    {
                        return Forbid(ret.Mensagem);
                    }
                    else
                    {
                        return BadRequest(ret);
                    }

                }
                else
                {
                    return Ok(ret);
                }

            }
            else
            {
                return Forbid("noPermission");
            }

        }

        [HttpPut("ToggleStatusCompany/{companyId}")]
        public async Task<IActionResult> ToggleStatusCompanyAsync(int companyId)
        {
            
            if (ssn.Profile == 1)
            {

                var ret = await _service.ToggleStatusCompanyAsync(companyId, ssn);

                if (ret.Erro)
                {

                    if (ret.Mensagem == "noPermission")
                    {
                        return Forbid(ret.Mensagem);
                    }
                    else
                    {
                        return BadRequest(ret);
                    }

                }
                else
                {
                    return Ok(ret);
                }

            }
            else
            {
                return Forbid("noPermission");
            }

        }

    }
}
