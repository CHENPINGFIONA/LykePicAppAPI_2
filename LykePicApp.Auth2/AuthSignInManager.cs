using Edulearn.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Edulearn.Auth
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
                throw new Exception("User does not exist.");
                //throw new Exception(Resource.ERROR_USERNAMEPASSWORDINCORRECT);
            }
            if (user.ExpiryDate <= DateTimeHelper.Now() || user.StartDate >= DateTimeHelper.Now())
            {
                throw new Exception(Resource.YourAccountHasBeenExpiredPleaseSeeYourSystemAdministratorForAssistance);
                //throw new Exception(Resource.ERROR_USERUNAUTHORIZEDPERIOD);
            }
            if (!user.IsEnabled)
            {
                throw new Exception(Resource.YourAccountHasBeenDisabledPleaseSeeYourSystemAdministratorForAssistance);
                //throw new Exception(Resource.ERROR_USERDISABLED);
            }
            if (await UserManager.IsLockedOutAsync(user.Id))
            {
                var timeLeft = user.LockoutEndDate - DateTimeHelper.Now();
                throw new Exception(Resource.PleaseContactLMSSupportHelpdeskForAccountLoginIssue);
                //throw new Exception($"{Resource.ERROR_USERLOCKOUT} please try again after {timeLeft.Minutes} minutes.");
            }
            if (await UserManager.CheckPasswordAsync(user, password))
            {
                return SignInStatus.Success;
            }
            if (shouldLockout)
            {
                // If lockout is requested, increment access failed count which might lock out the user
                await UserManager.AccessFailedAsync(user.Id);
                if (await UserManager.IsLockedOutAsync(user.Id))
                {
                    var timeLeft = user.LockoutEndDate - DateTimeHelper.Now();
                    throw new Exception(Resource.PleaseContactLMSSupportHelpdeskForAccountLoginIssue);
                    //throw new Exception($"{Resource.ERROR_USERLOCKOUT} please try again after {timeLeft.Minutes} minutes.");
                }
            }

            //throw new Exception($"{Resource.ERROR_USERNAMEPASSWORDINCORRECT} You have {GetLockoutCountLeft(user.Id)} tries left.");
            throw new Exception();
        }

        public async Task SignInAsync(string userName)
        {
            var user = UserManager.FindByName(userName);
            await SignInAsync(user, false, false);

            user.LastLoginDate = DateTimeHelper.Now();
            await UserManager.UpdateAsync(user);

            await UserManager.ResetAccessFailedCountAsync(user.Id);
        }

        public async Task<IdentityResult> SignOutAsync(string userId)
        {
            try
            {
                var user = UserManager.FindById(Guid.Parse(userId));
                user.IsEnabled = false;
                user.LastLoginDate = DateTimeHelper.Now();
                await UserManager.UpdateAsync(user);
            }
            catch (Exception exp)
            {
                return new IdentityResult(exp.Message);
            }

            return IdentityResult.Success;
        }

        private int GetLockoutCountLeft(Guid userId)
        {
            return UserManager.MaxFailedAccessAttemptsBeforeLockout
                - UserManager.GetAccessFailedCountAsync(userId).Result;
        }
    }
}
