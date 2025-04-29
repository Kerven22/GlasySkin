using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shared.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace GlasySkin.Middleware
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext httpContext, ProblemDetailsFactory problemDetails)
        {
            try
            {
                await next.Invoke(httpContext); 
            }
            catch(Exception exception)
            {
                var problem = exception switch
                {
                    ValidationException => problemDetails.CreateProblemDetails(httpContext, 100, "ValidationException", detail:exception.Message),
                    _=> problemDetails.CreateProblemDetails(httpContext, 500, "Unhendled error pease contact us!", detail:exception.Message)
                };


                await httpContext.Response.WriteAsJsonAsync(problem); 
            }
        }
    }
}