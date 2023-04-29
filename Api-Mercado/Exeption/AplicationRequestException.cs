using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Net;

namespace Api_Mercado.Exeption
{
    [Serializable]
    public class AplicationRequestException : Exception
    {
        public Retorno Resposta { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public AplicationRequestException(string message, ModelStateDictionary modelState) : base(message)
        {
            Resposta = new Retorno()
            {
                Id = Guid.NewGuid().ToString(),
                Message = message,
                Campos = modelState?.Keys
                    .SelectMany(campo =>
                    {
                        modelState.TryGetValue(campo, out var value);
                        return value?.Errors.Select(erro => new CamposErro()
                        {
                            Campo = campo,
                            Message = erro.ErrorMessage
                        }) ?? Enumerable.Empty<CamposErro>();
                    })
                    .ToList() ?? new List<CamposErro>()
            };
            StatusCode = HttpStatusCode.BadRequest;
        }
        public AplicationRequestException(string message,HttpStatusCode statusCode) : base(message) {
            Resposta = new Retorno()
            {
                Id = Guid.NewGuid().ToString(),
                Message = message,
                Campos = null
            };
            StatusCode = statusCode;
        }
    }
    public class Retorno
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "mensagem")]
        public string? Message { get; set; }

        [JsonProperty("campos", NullValueHandling = NullValueHandling.Ignore)]
        public List<CamposErro>? Campos { get; set; } = new List<CamposErro>();
    }
    public class CamposErro 
    {
        [JsonProperty(PropertyName = "campo")]
        public string? Campo { get; set; }

        [JsonProperty(PropertyName = "mensagem")]
        public string? Message { get; set; }
    }

}
