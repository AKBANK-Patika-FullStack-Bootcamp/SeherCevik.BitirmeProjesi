using siteManagement.Logger;
using System.Net;
using System.Text.Json;

namespace siteManagement.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppLogger _logger;

        public CustomExceptionMiddleware(RequestDelegate next, AppLogger logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception err)
            {
                await HandleExceptionAsync(httpContext, err);
            }
        }


        //! Yakalanan hataları formatlayarak kullanıcıya bilgilendirme döner
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            string name = "UndefinedError";

            switch (exception)
            {
                case Exception:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    name = exception.GetType().Name;

                    _logger.ErrorLog(exception.Message);

                    break;
            }

            var response = JsonSerializer.Serialize(new
            {
                Name = name,
                Message = exception.Message,
                Code = exception.HResult,
                StatusCode = context.Response.StatusCode,

            });

            await context.Response.WriteAsync(response);
        }
    }
}
