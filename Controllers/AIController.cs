using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("AI")]
    [Authorize]
    public class AIController : BaseController
    {

        private readonly IAIService _service;

        public AIController(IAIService service)
        {
            _service = service;
        }

    }
}
