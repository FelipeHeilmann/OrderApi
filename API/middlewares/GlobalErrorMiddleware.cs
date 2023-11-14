using Application.errors;
using System.Net;
using System.Text.Json;

namespace API.middlewares
{
    public class GlobalErrorMiddleware
    {
        private readonly RequestDelegate _next;
 

        public GlobalErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseError err)
            {
                await HandleExeptionAsync(context, err);
            }
        }

        private static Task HandleExeptionAsync(HttpContext context, BaseError err) {

            string message = err.Message;
            
            var result = JsonSerializer.Serialize(new { message = err.Message, code = err.StatusCode }); 
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)err.StatusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
