using Microsoft.AspNet.Identity;
using Edulearn.BLL;
using System;
using System.Threading.Tasks;

namespace Edulearn.Auth
{
    public class AuthUserStore :
        IUserStore<AuthIdentityUser, Guid>,
        IUserPasswordStore<AuthIdentityUser, Guid>,
        IUserLockoutStore<AuthIdentityUser, Guid>
    {
        private User userBll;

        public AuthUserStore()
        {
            if (userBll == null)
            {
                userBll = new User();
            }
        }

        public Task CreateAsync(AuthIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AuthIdentityUser user)
        {
            userBll.Save(user.ToUser(), user.UserId);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(AuthIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SavePasswordHistory(AuthIdentityUser user)
        {
            userBll.Save(user.ToUser(), user.UserId);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            userBll.Dispose();
        }

        public Task<AuthIdentityUser> FindByIdAsync(Guid userId)
        {
            var user = userBll.GetItemByUserId(userId);
            return Task.FromResult(AuthIdentityUser.From(user));
        }

        public Task<AuthIdentityUser> FindByNameAsync(string userName)
        {
            var user = userBll.GetItemByUserName(userName);
            return Task.FromResult(AuthIdentityUser.From(user));
        }

        public Task SetPasswordHashAsync(AuthIdentityUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(AuthIdentityUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(AuthIdentityUser user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(AuthIdentityUser user)
        {
            return Task.FromResult(new DateTimeOffset(user.LockoutEndDate));
        }

        public Task SetLockoutEndDateAsync(AuthIdentityUser user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDate = ConvertHelper.ToDate(lockoutEnd);
            return Task.CompletedTask;
        }

        public Task<int> IncrementAccessFailedCountAsync(AuthIdentityUser user)
        {
            user.AccessFailedCount++;
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task ResetAccessFailedCountAsync(AuthIdentityUser user)
        {
            user.AccessFailedCount = 0;
            return Task.CompletedTask;
        }

        public Task<int> GetAccessFailedCountAsync(AuthIdentityUser user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(AuthIdentityUser user)
        {
            return Task.FromResult(true);
        }

        public Task SetLockoutEnabledAsync(AuthIdentityUser user, bool enabled)
        {
            return Task.CompletedTask;
        }
    }
}
