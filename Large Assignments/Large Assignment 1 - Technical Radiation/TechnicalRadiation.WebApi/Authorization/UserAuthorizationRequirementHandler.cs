using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Exceptions;

namespace TechnicalRadiation.WebApi.Authorization
{
    public class UserAuthorizationRequirementHandler : AuthorizationHandler<UserAuthorizationRequirement>
    {
        /// <summary>
        /// The http context to extract header value for authorization from user
        /// </summary>
        private IHttpContextAccessor _httpContextAccessor = null;

        /// <summary>
        /// Super secret shared key between server and authorized users;
        /// Only users that know and include the secret key can request on authorized routes
        /// </summary>
        private string _secretKey = "Th3z3_4r3-n0t_&_th3_%_dr01dz-#_y0u$r3_!-l00k1n9&&_f0r";

        /// <summary>
        /// Setup http context to access request authorization header
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public UserAuthorizationRequirementHandler(IHttpContextAccessor httpContextAccessor) => 
            _httpContextAccessor = httpContextAccessor;

        /// <summary>
        /// Check if user fulfills requirement to be authorized to use route,
        /// i.e. if user includes the secret key in the authorization header
        /// </summary>
        /// <param name="context">authorization handler context</param>
        /// <param name="requirement">requirement user must fulfill</param>
        /// <returns>Asynchronous task indicating authorization fail or success</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAuthorizationRequirement requirement)
        {
            // Check if user has secret key in authorization header
            // If they do, authorize user for route - otherwise 401 (Unauthorized)
            string userProvidedKey = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if(userProvidedKey != _secretKey) throw new AuthorizationException("Client is unauthorized for request");
            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

