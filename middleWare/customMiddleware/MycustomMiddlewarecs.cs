
namespace middleWare.customMiddleware
{
    public class MycustomMiddlewarecs : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {   
            await context.Response.WriteAsync("Custom Middleware before next<br>");
            await next(context);
            await context.Response.WriteAsync("Custom Middleware after next<br>");
        }
    }
}
