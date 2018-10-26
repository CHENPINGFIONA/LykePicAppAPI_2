using System;
using System.Security.Claims;
using System.Security.Principal;

namespace LykePicApp.Auth
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this IIdentity identity)
        {
            var userId = ((ClaimsIdentity)identity).FindFirst("Id").Value;

            return new Guid(userId);
        }
    }
}
