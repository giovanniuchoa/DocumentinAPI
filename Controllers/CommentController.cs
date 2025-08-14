using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("Comment")]
    [Authorize]
    public class CommentController : BaseController
    {

        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

    }
}
