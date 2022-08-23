using API_LoggerCore.CustomLogger;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_MiddlewareCore.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        private readonly CustomLogger customLogger;
        private readonly ILogger logger;
        
        public CustomMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            this.next = next;
            this.logger = logger.CreateLogger<CustomMiddleware>();
            customLogger = new CustomLogger(this.logger);
          
           
            
        }
        public async Task InvokeAsync(HttpContext context)
        {

            customLogger.Info("ENTRO EN EL MIDDLEWARE");
            await next(context);    
          
        }
    }
}
