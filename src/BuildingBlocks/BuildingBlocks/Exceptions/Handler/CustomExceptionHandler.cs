using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Exceptions.Handler;

public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError("Error Message: {exceptionMessage}, Time of occurance {time}", exception.Message, DateTime.UtcNow);

        (string Detail, String Title, int StatusCode) details = exception switch
        {
            InternalServerException => (
                exception.Message,
                "Internal Server Error",
                StatusCodes.Status500InternalServerError),

            ValidationException => (
                exception.Message,
                "Validation Error",
                StatusCodes.Status400BadRequest),

            BadHttpRequestException => (
                exception.Message,
                "Bad Request",
                StatusCodes.Status400BadRequest),

            NotFoundException => (
                exception.Message,
                "Not Found",
                StatusCodes.Status404NotFound),

            _ => (
                exception.Message,
                exception.GetType().Name,
                StatusCodes.Status500InternalServerError)
        };

        var problemDetails = new ProblemDetails
        {
            Title = details.Title,
            Detail = details.Detail,
            Status = details.StatusCode,
            Instance = context.Request.Path
        };

        problemDetails.Extensions.Add("traceId", context.TraceIdentifier);

        if (exception is ValidationException validationException)
        {
            problemDetails.Extensions.Add("errors", validationException.Errors);
        }

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);

        return true;

    }
}
