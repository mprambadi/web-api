using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;

namespace web_test_api.Middleware
{
    public interface ICustomAuthMiddleware
    {
        Task InvokeAsync(HttpContext context);
    }

   
}