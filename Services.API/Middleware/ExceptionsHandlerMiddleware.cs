using Serilog;
using Services.Application.Exceptions;
using System.Text.Json;

namespace Services.API.Middleware
{
    public class ExceptionsHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (FluentValidation.ValidationException ex)
            {
                Log.Error("Validation error: {ex}", ex);
                await HandleExceptionAsync(context, 400, ex.Message);
            }
            catch (DataException ex)
            {
                Log.Error("Data error: {ex}", ex);
                await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                Log.Information("The operation was canceled: {ex}", ex);
                await HandleExceptionAsync(context, 499, "The operation was canceled");
            }
            catch (NotFoundException ex)
            {
                Log.Error("Not found: {ex}", ex);
                await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
            }
            catch (ConflictException ex)
            {
                Log.Error("Conflict: {ex}", ex);
                await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                Log.Fatal("Server error: {ex}", ex);
                await HandleExceptionAsync(context, 500, "Internal server error");
            }

        }

        private async Task HandleExceptionAsync(HttpContext context, int statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new
            {
                statusCode,
                message,
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
