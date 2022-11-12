using System;
using BasicBilling.Core.Exceptions;
using BasicBilling.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasicBilling.Infrastructure.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BasicBillingException))
            {
                var exception = (BasicBillingException)context.Exception;
                var error = new ErrorResponse
                {
                    Type = exception.Type.ToString(),
                    Details = new[] { exception.Message }
                };
                var response = new APIResponse<string>(null, error);

                context.Result = new ObjectResult(response);
                context.ExceptionHandled = true;
                switch (exception.Type)
                {
                    case BasicBillingExceptionType.BadRequest:
                        context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case BasicBillingExceptionType.InternalServerError:
                        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                    case BasicBillingExceptionType.NotFound:
                        context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                }
            }
        }
    }
}

