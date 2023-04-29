using Api_Mercado.Exeption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api_Mercado.Atribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAtribute : Attribute, IAuthorizationFilter
    {
        private const string ACESSO_NAO_PERMITIDO = "Acesso negado.";

        public AuthorizeAtribute()
        {

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous) return;

            var user = context.HttpContext.Items["Id"]!;

            if (user == null) throw new AplicationRequestException(ACESSO_NAO_PERMITIDO, HttpStatusCode.Unauthorized);

        }
    }
}
