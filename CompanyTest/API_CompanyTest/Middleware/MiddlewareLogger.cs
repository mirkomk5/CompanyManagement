namespace API_CompanyTest.Middleware
{
    public class MiddlewareLogger : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine($"Logger system: request => {context.Request.Method} {context.Request.Path}");
            await next(context);
            Console.WriteLine($"Logger system: response => {context.Response.StatusCode}");
        }
    }
}
