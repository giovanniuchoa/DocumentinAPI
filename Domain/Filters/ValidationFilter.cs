using DocumentinAPI.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DocumentinAPI.Domain.Filters
{
    public class ValidationFilter : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {

                var oRetorno = new Retorno<byte>();

                var erro = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .FirstOrDefault();

                oRetorno.SetErro(erro.ErrorMessage);

                context.Result = new BadRequestObjectResult(oRetorno);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

    }
}
