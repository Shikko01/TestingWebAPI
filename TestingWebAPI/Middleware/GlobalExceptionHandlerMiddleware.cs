using System.Net;
using System.Text.Json;

namespace TestingWebAPI.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                    _logger.LogError(ex,"Error occured");

                    var errorResponse = new
                    {
                        Title = "An internal server error occurred.",
                        Status = (int)HttpStatusCode.InternalServerError,
                        Detail = ex.Message
                    };

                    context.Response.StatusCode = errorResponse.Status;
                    context.Response.ContentType = "application/json";

                    //var json = JsonSerializer.Serialize(errorResponse);
                    //await context.Response.WriteAsync(json);

                    await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
