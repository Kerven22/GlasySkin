using Microsoft.AspNetCore.Diagnostics;
using Shared.Errors;
using System.Net;

namespace GlasySkin.Extentions
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); 
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode, 
                            Message = "Intrnal Server Error"
                        }.ToString());
                    }
                });
            });
        }
    }
}
