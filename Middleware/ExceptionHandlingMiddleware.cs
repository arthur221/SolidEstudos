using System.Net;
using System.Text.Json;
using SolidEstudos.Exceptions;

namespace SolidEstudos.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
        catch (ReservaException ex)
        {
            _logger.LogWarning(ex, "Regra de negócio violada: {Mensagem}", ex.Message);
            await EscreverErroAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro inesperado no sistema");
            await EscreverErroAsync(context, HttpStatusCode.InternalServerError, "Erro interno no servidor.");
        }
    }

    private static async Task EscreverErroAsync(HttpContext context, HttpStatusCode statusCode, string mensagem)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var resposta = JsonSerializer.Serialize(new { erro = mensagem });
        await context.Response.WriteAsync(resposta);
    }
}
