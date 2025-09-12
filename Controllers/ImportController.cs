using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{
    public class ImportController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
