using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FinalExamAsd.Exceptions
{
    public class GlobalExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                BadRequestException => 400,
                NotFoundException => 404,
                _ => 500
            };

            var error = new ApiError(
        Message: context.Exception.Message,
         Details: context.Exception.InnerException?.Message ?? context.Exception.StackTrace
        );


            context.Result = new ObjectResult(error) { StatusCode = statusCode };
        }
    }


}
