using System;
using System.Security.Claims;
using System.Threading.Tasks;
using LykePicApp.Model;
using Microsoft.AspNet.Identity;

namespace LykePicApp.Auth
{
    public class AuthIdentityUser : User, IUser<Guid>
    {
        public Guid Id => base.UserId;

        public static AuthIdentityUser From(User user)
        {
            return new AuthIdentityUser()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                ProfilePicture = user.ProfilePicture,
                Password = user.Password,
                CreatedDate = user.CreatedDate,
                Timestamp = user.Timestamp
            };
        }

        public User ToUser()
        {
            return new User()
            {
                UserId = this.UserId,
                UserName = this.UserName,
                Email = this.Email,
                ProfilePicture = this.ProfilePicture,
                Password = this.Password,
                CreatedDate = this.CreatedDate,
                Timestamp = this.Timestamp
            };
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AuthUserManager manager)
        {
            var identity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim("Id", Id.ToString()));
            identity.AddClaim(new Claim("UserName", UserName));
            identity.AddClaim(new Claim("Email", Email));

            return identity;
        }
    }
}
