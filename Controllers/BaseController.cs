using DocumentinAPI.Authentication;
using DocumentinAPI.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DocumentinAPI.Controllers
{
    public class BaseController : ControllerBase
    {

        protected UserSession ssn => TokenService.GetClaimsData(HttpContext.User);

    }
}
