using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace TechnicalRadiation.WebApi.Authorization
{
    public class HasAuthorizationHeaderAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContext httpContext)
        {
            string token = "AXtAOuRVErySeCRETTokenAtXA";
            string authHeader = httpContext.Request.Headers["Authorization"];
            
            return authHeader == token;
        }

    }
}