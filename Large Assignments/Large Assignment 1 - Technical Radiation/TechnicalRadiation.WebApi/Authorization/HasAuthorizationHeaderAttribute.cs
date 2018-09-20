namespace TechnicalRadiation.WebApi.Authorization
{
    public class HasAuthorizationHeaderAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string token = "AXtAOuRVErySeCRETTokenAtXA";
            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader == token) {
              return true;
            }
            return false;
        }

    }
}