using System.Net;

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
                if (ex.Message.Contains("error: response id 200"))
                {
                    _logger.LogError(ex, "Response ID 200 error occurred.");

                    var errorResponse = new
                    {
                        Title = "An internal server error occurred.",
                        Status = (int)HttpStatusCode.InternalServerError,
                        Detail = ex.Message
                    };

                    context.Response.StatusCode = errorResponse.Status;
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsJsonAsync(errorResponse);
                }
            }
        }
    }
}
