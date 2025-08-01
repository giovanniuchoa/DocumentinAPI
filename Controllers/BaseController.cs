using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DocumentinAPI.Controllers
{
    public class BaseController : ControllerBase
    {

        protected UserClaimDTO ssn => TokenService.GetClaimsData(HttpContext.User);

    }
}
