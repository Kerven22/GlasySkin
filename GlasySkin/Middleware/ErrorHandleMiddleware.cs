using Shared.Exceptions;

namespace GlasySkin.Middleware
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext); 
            }
            catch(Exception exception)
            {
                var es = exception switch
                {
                    CategoryNotFoundException => StatusCodes.Status410Gone,

                    _ => StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}