using ALIbrary.Infrastructure.Exceptions;
using System.Text.Json;

namespace ALIbrary.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            await HandleException(
                context,
                StatusCodes.Status404NotFound,
                ex.Message);
        }
        catch (BadRequestException ex)
        {
            await HandleException(
                context,
                StatusCodes.Status400BadRequest,
                ex.Message);
        }
        catch (Exception)
        {
            await HandleException(
                context,
                StatusCodes.Status500InternalServerError,
                "An unexpected error occurred.");
        }
    }

    private static async Task HandleException(
        HttpContext context,
        int statusCode,
        string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new
        {
            Status = statusCode,
            Message = message
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}