using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{
    public class TaskController : BaseController
    {

        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

    }
}
