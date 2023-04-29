using Api_Mercado.Exeption;
using Newtonsoft.Json;
using System.Net;

namespace Api_Mercado.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AplicationRequestException ex) {
                await HandleValidateException(httpContext, ex);
            }
            catch(Exception ex)
            {
                await HandleExeptionAsync(httpContext, ex, _logger);
            }
        }
        public static Task HandleValidateException(HttpContext context,AplicationRequestException exeption)
        {
            var code = exeption.StatusCode;
            var result = JsonConvert.SerializeObject(exeption.Resposta);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
        public static Task HandleExeptionAsync(HttpContext context,Exception exeption,ILogger<ErrorHandlerMiddleware> logger) {
            string id_error = Guid.NewGuid().ToString();

            logger.LogError($"Mensagem Erro {id_error}: {exeption.Message}");
            logger.LogError($"StackTrace {id_error}: {exeption.ToString()}");

            var code = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new InternalError()
            {
                Id = id_error,
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode= (int)code;
            return context.Response.WriteAsync(result);
        }
    }
    public class InternalError 
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "mensagem")]
        public string Mensagem { get; set; } = "Erro inesperado no Servidor.";
    }

}
