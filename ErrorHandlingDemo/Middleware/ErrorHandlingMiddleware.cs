
using ErrorHandlingDemo.Contracts;
using ErrorHandlingDemo.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace DataOne.WorkspaceHub.API.Exceptions
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = DeterminateStatusCode(exception);

            var errorResponse = new ErrorResponse
            {
                Message = exception.Message
            };

            return context.Response.WriteAsJsonAsync(errorResponse);
        }


        private static int DeterminateStatusCode(Exception exception)
        {
            return exception switch
            {
                CustomException wsh => wsh.StatusCode,
                NotImplementedException => StatusCodes.Status501NotImplemented,
                ArgumentOutOfRangeException => StatusCodes.Status400BadRequest,
                ArgumentException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                TimeoutException => StatusCodes.Status504GatewayTimeout,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}