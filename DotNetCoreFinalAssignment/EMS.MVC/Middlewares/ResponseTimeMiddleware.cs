using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.MVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ResponseTimeMiddleware
    {
        private const string RESPONSE_TIME = "X-Response-Time-ms";
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ResponseTimeMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger("ResponseTimeMiddleware");
        }

        public Task Invoke(HttpContext httpContext)
        {
            var watch = new Stopwatch();
            watch.Start();
            httpContext.Response.OnStarting(() => {
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;

                httpContext.Response.Headers[RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();
                _logger.LogInformation(responseTimeForCompleteRequest.ToString());
                return Task.CompletedTask;
            });
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ResponseTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseTimeMiddleware>();
        }
    }
}
