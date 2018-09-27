using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace TechnicalRadiation.WebApi.Authorization
{
    /// <summary>
    /// Implements user requirement to access restricted routes via authorization requirement
    /// </summary>
    public class UserAuthorizationRequirement : IAuthorizationRequirement
    {
        public UserAuthorizationRequirement() { }
    }
}