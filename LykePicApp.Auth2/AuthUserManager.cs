using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace Edulearn.Auth
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

            manager.UserTokenProvider = new AuthUserTokenProvider();

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
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

        public override async Task<IdentityResult> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            var passwordStore = GetPasswordStore();
            var user = await FindByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User does not exist.");
            }

            if (await VerifyPasswordAsync(passwordStore, user, currentPassword))
            {
                var result = await UpdatePassword(passwordStore, user, newPassword);
                if (!result.Succeeded)
                {
                    return result;
                }

                user.ChangePasswordOnNextLogin = false;
                return await UpdateAsync(user);
            }

            return IdentityResult.Failed("The password you entered is incorrect. Please re-enter your current password.");
        }

        private IUserPasswordStore<AuthIdentityUser, Guid> GetPasswordStore()
        {
            var cast = Store as IUserPasswordStore<AuthIdentityUser, Guid>;
            if (cast == null)
            {
                throw new NotSupportedException("StoreNotIUserPasswordStore");
            }
            return cast;
        }
    }
}
