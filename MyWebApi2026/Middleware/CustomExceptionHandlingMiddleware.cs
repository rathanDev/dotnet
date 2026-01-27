using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi2026.Middleware;

public class CustomExceptionHandlingMiddleware
{

    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionHandlingMiddleware> _logger;
    public CustomExceptionHandlingMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = exception switch
        {
            ArgumentException => HttpStatusCode.BadRequest,
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            KeyNotFoundException => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError
        };

        var response = new ProblemDetails
        {
            Status = (int)statusCode,
            Title = "An error occurred while processing your request.",
            Detail = exception.Message,
            Instance = context.Request.Path
        };

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = response.Status.Value;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

}
