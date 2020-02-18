using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;

namespace web_test_api.Middleware
{
 
    public class CustomAuthMiddleware : ICustomAuthMiddleware
    {

        private readonly RequestDelegate _next;

        public CustomAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers["Authorization"] == "hello")
            {
                await _next(context);
            }
            else
            {

                var text = "takbisa";

                var data = System.Text.Encoding.UTF8.GetBytes(text);
                await context.Response.Body.WriteAsync(data, 0, data.Length);
            }

        }

    }


    public static class AuthMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomAuthMmiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthMiddleware>();
        }
    }
}