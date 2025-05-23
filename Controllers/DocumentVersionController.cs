using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{

    [Route("DocumentVersion")]
    [Authorize]
    public class DocumentVersionController : BaseController
    {

    }
}
