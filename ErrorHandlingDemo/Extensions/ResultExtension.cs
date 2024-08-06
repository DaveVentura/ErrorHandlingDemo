using Microsoft.AspNetCore.Mvc;
using LanguageExt.Common;
using ErrorHandlingDemo.Contracts;
using ErrorHandlingDemo.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ErrorHandlingDemo.Extensions
{
    public static class ResultExtension
    {
        public static IActionResult ToResultResponse<TResult, TContract>(this Result<TResult> result, Func<TResult, TContract> mapper)
        {
            return result.Match<IActionResult>(obj =>
            {
                var response = mapper(obj);
                return new OkObjectResult(response);
            }, exception =>
            {
                return new ObjectResult(new ErrorResponse { Message = exception.Message })
                {
                    StatusCode = DeterminateStatusCode(exception)
                };
            });
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
}
