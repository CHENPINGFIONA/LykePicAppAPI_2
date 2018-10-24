using System;
using System.Security.Claims;
using System.Security.Principal;

namespace Edulearn.Auth
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this IIdentity identity)
        {
            var userId = ((ClaimsIdentity)identity).FindFirst("Id").Value;

            return ConvertHelper.ToGuid(userId);
        }

        public static int GetRole(this IIdentity identity)
        {
            var role = ((ClaimsIdentity)identity).FindFirst("Role").Value;

            return ConvertHelper.ToInt(role);
        }

        public static string GetDisplayName(this IIdentity identity)
        {
            return ((ClaimsIdentity)identity).FindFirst("DisplayName").Value;
        }

        public static string GetCookieId(this IIdentity identity)
        {
            return ((ClaimsIdentity)identity).FindFirst("CookieId").Value;
        }
    }
}
