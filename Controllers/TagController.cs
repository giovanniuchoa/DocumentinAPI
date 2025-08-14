using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Tag")]
    [Authorize]
    public class TagController : BaseController
    {

        private readonly ITagService _service;

        public TagController(ITagService service)
        {
            _service = service;
        }

    }
}
