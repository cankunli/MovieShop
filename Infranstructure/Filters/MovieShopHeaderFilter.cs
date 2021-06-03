using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infranstructure.Filters
{
    public class MovieShopHeaderFilter : IActionFilter
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<MovieShopHeaderFilter> _logger;

        public MovieShopHeaderFilter(ICurrentUserService currentUserService, ILogger<MovieShopHeaderFilter> logger)
        {
            _currentUserService = currentUserService;
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log each and every user's IP address, his name if authenticated, authentication status, date time
            // context.HttpContext.Response.Headers.Add("job", "antra.com/jobs");

            var email = _currentUserService.Email;
            var datetime = DateTime.UtcNow;
            var isAuthenticated = _currentUserService.IsAuthenticated;
            var name = _currentUserService.FullName;

            // log this info to text files
            // System.IO
            // Serilog, NLog, Log4net

            //var log = new LoggerConfiguration()
            //    .WriteTo.File("logINFO.txt")
            //    .CreateLogger();

            //log.Information("User Email: {@Email}, \n Log Time: {@datetime}, \n User isAuthenticated? {@isAuthenticated}, \n Username: {@name}", email, datetime, isAuthenticated, name);
            var message = $"User: {name}, Email: {email}, Authentication: {isAuthenticated}, visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(message);
            _logger.LogCritical(message);

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
