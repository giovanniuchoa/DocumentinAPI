using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Controllers
{
    public class DocumentValidationController : BaseController
    {

        private readonly IDocumentValidationService _service;

        public DocumentValidationController(IDocumentValidationService service)
        {
            _service = service;
        }   



    }
}
