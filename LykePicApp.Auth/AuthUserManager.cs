using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace LykePicApp.Auth
{
    public class AuthUserManager : UserManager<AuthIdentityUser, Guid>
    {
        public AuthUserManager(IUserStore<AuthIdentityUser, Guid> store) : base(store) { }

        public static AuthUserManager Create(IdentityFactoryOptions<AuthUserManager> options, IOwinContext context)
        {
            var manager = new AuthUserManager(new AuthUserStore());
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AuthIdentityUser, Guid>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure password hasher
            manager.PasswordHasher = new AuthPasswordHasher();

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(30);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            return manager;
        }

        public override async Task<IdentityResult> UpdateAsync(AuthIdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            await Store.UpdateAsync(user);
            return IdentityResult.Success;
        }
    }
}
