using BarberBoss.Communication.Responses;
using BarberBoss.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberBoss.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BarberBossException)
                HandleProjectException(context);
            else
                ThrowUnknowException(context);
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var ex = (BarberBossException)context.Exception;

            context.HttpContext.Response.StatusCode = (int)ex.GetHttpStatusCode();
            context.Result = new ObjectResult(new ErrorMessageResponse(ex.GetErrors()));
        }

        private void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ErrorMessageResponse("ERRO DESCONHECIDO"));
        }
    }
}
