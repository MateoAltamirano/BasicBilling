using System;
using BasicBilling.Core.Exceptions;
using BasicBilling.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasicBilling.Infrastructure.Filters
{
	public class ValidationFilter : IAsyncActionFilter
	{
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var error = new ErrorResponse
                {
                    Type = BasicBillingExceptionType.BadRequest.ToString(),
                    Details = context.ModelState.Values.Select(value => value.Errors.First().ErrorMessage)
                };
                var response = new APIResponse<string?>(null, error);
                context.Result = new BadRequestObjectResult(response);

                return;
            }
            await next();
        }
    }
}

