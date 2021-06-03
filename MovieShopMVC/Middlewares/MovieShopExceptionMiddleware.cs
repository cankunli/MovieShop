using ApplicationCore.Exceptions;
using ApplicationCore.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShopMVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Middleware is catching exception");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            // get all the information you wanna log and use Serilog or NLog to log exceptions to text/json files

            _logger.LogError("Starting Logging for exception");

            ClaimsPrincipal claimsPrincipal = httpContext.User;

            var claimItems = new List<string>();
            foreach (Claim claim in claimsPrincipal.Claims)
            {
                claimItems.Add(claim.Value);
            }

            var errorModel = new ErrorResponseModel
            {
                ExceptionMessage = ex.Message,
                ExceptionStackTrace = ex.StackTrace,
                InnerExceptionMessage = ex.InnerException?.Message,
                FullName = claimItems[0] + " " + claimItems[1],
                UserId = claimItems[2],
                Email = claimItems[3],
                ExceptionDate = DateTime.UtcNow
                //Email = httpContext.User.Identity.ToString(email),
                //Email = httpContext.User.Claims.GetType.
                //Email = httpContext.User.em
            };

            switch (ex)
            {
                case ConflictException conflictException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;

                case NotFoundException notFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case UnauthorizedAccessException unauthorized:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case Exception exception:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            // seriLog to log  errorModel along with 
            var message = $"Fullname: {errorModel.FullName}, UserId: {errorModel.UserId}, User email: {errorModel.Email}, Exception time at {errorModel.ExceptionDate.ToLongTimeString()}";

            //$"SHOW ME SOMETHING!!!!!!!" + errorModel.ExceptionMessage + ": " + errorModel.UserId + " " + errorModel.FullName + " " +
            //             errorModel.Email + " " + errorModel.IsAuthorized + " " + errorModel.ExceptionDate;
            _logger.LogInformation(message);
            _logger.LogCritical(message);

            // redirect to error page
            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
