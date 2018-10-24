using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace Edulearn.Auth
{
    public class AuthUserTokenProvider : IUserTokenProvider<AuthIdentityUser, Guid>
    {
        public Task<string> GenerateAsync(string purpose, UserManager<AuthIdentityUser, Guid> manager, AuthIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidProviderForUserAsync(UserManager<AuthIdentityUser, Guid> manager, AuthIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task NotifyAsync(string token, UserManager<AuthIdentityUser, Guid> manager, AuthIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<AuthIdentityUser, Guid> manager, AuthIdentityUser user)
        {
            return purpose == "ResetPassword" ? Task.FromResult(true) : Task.FromResult(false);
        }
    }
}
