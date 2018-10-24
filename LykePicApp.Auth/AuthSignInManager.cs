using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LykePicApp.Auth
{
    public class AuthSignInManager : SignInManager<AuthIdentityUser, Guid>
    {
        public AuthSignInManager(AuthUserManager userManager, IAuthenticationManager authenticationManager)
           : base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AuthIdentityUser user)
        {
            return user.GenerateUserIdentityAsync((AuthUserManager)UserManager);
        }

        public static AuthSignInManager Create(IdentityFactoryOptions<AuthSignInManager> options, IOwinContext context)
        {
            return new AuthSignInManager(context.GetUserManager<AuthUserManager>(), context.Authentication);
        }

        public async Task<IdentityResult> SignInAsync(string userName, string password)
        {
            try
            {
                await PasswordSignInAsync(userName, password, false, true);
                await SignInAsync(userName);
            }
            catch (Exception exp)
            {
                return new IdentityResult(exp.Message);
            }

            return IdentityResult.Success;
        }

        public override async Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            if (UserManager == null)
            {
                throw new ArgumentNullException("user manager is null");
            }

            var user = await UserManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new Exception("UserName or Password is incorrect.");
            }

            throw new Exception();
        }

        public async Task SignInAsync(string userName)
        {
            var user = UserManager.FindByName(userName);
            await SignInAsync(user, false, false);

            await UserManager.UpdateAsync(user);

            await UserManager.ResetAccessFailedCountAsync(user.Id);
        }

        public async Task<IdentityResult> SignOutAsync(string userId)
        {
            try
            {
                var user = UserManager.FindById(Guid.Parse(userId));
                await UserManager.UpdateAsync(user);
            }
            catch (Exception exp)
            {
                return new IdentityResult(exp.Message);
            }

            return IdentityResult.Success;
        }
    }
}
