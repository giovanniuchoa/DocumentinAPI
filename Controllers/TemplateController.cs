using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Template")]
    [Authorize]
    public class TemplateController : BaseController
    {

        private readonly ITemplateService _service;

        public TemplateController(ITemplateService service)
        {
            _service = service;
        }



    }
}
