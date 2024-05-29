using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;
using System.Text.Json;

namespace ClassOrganizer.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly string MENSAGEM_ERRO_DELETE = "The DELETE statement conflicted with the REFERENCE constraint";

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (SqlException ex)
            {
                await HandleSqlExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {                
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            var response = new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", new string[] { "Ocorreu um erro, tente novamente mais tarde, e se o erro persistir entre em contato com o suporte." } }
            });

            var result = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(result);
        }

        private Task HandleSqlExceptionAsync(HttpContext context, SqlException exception)
        {
            if (exception.Message.Contains(MENSAGEM_ERRO_DELETE))
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;

                var response = new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Messages", new string[] { "Nao foi possivel apagar esse registro pois ele possui uma associacao com outros." } }
                });

                var result = JsonSerializer.Serialize(response);
                return context.Response.WriteAsync(result);
            }
            
            return HandleExceptionAsync(context, exception);
        }
    }
}
