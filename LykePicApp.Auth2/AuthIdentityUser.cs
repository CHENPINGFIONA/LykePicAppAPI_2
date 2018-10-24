using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Edulearn.Model;

namespace Edulearn.Auth
{
    public class AuthIdentityUser : UserDM, IUser<Guid>
    {
        public Guid Id => base.UserId;

        public static AuthIdentityUser From(UserDM user)
        {
            return MapHelper.Map<UserDM, AuthIdentityUser>(user);
        }

        public UserDM ToUser()
        {
            return MapHelper.Map<AuthIdentityUser, UserDM>(this);
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AuthUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var identity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            identity.AddClaim(new Claim("Id", Id.ToString()));
            identity.AddClaim(new Claim("UserName", UserName));
            identity.AddClaim(new Claim("DisplayName", DisplayName));
            identity.AddClaim(new Claim("Role", Role.ToString()));
            identity.AddClaim(new Claim("CookieId",CookieId.ToString()));

            return identity;
        }
    }
}
