using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApplication1.Middlewares
{
    public class DeviceIdCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public DeviceIdCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            Debug.WriteLine("Access Time: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            return _next(httpContext);
        }
    }

    public static class DeviceIdCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseDeviceIdCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DeviceIdCheckMiddleware>();
        }
    }
}
