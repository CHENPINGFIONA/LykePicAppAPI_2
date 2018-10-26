using LykePicApp.BAL;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace LykePicApp.Auth
{
    public class AuthUserStore :
        IUserStore<AuthIdentityUser, Guid>,
        IUserPasswordStore<AuthIdentityUser, Guid>
    {
        private UserBAL userBAL;

        public AuthUserStore()
        {
            if (userBAL == null)
            {
                userBAL = new UserBAL();
            }
        }

        public Task CreateAsync(AuthIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AuthIdentityUser user)
        {
            userBAL.Save(user.ToUser());
            return Task.CompletedTask;
        }

        public Task DeleteAsync(AuthIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            userBAL.Dispose();
        }

        public Task<AuthIdentityUser> FindByIdAsync(Guid userId)
        {
            var user = userBAL.GetUserById(userId);
            return Task.FromResult(AuthIdentityUser.From(user));
        }

        public Task<AuthIdentityUser> FindByNameAsync(string userName)
        {
            var user = userBAL.GetUserByName(userName);
            return Task.FromResult(AuthIdentityUser.From(user));
        }

        public Task<string> GetPasswordHashAsync(AuthIdentityUser user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(AuthIdentityUser user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.Password));
        }

        public Task SetPasswordHashAsync(AuthIdentityUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}
