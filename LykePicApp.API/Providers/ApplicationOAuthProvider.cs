using LykePicApp.Auth;
using LykePicApp.BAL;
using LykePicApp.DAL;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LykePicApp.API
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<AuthUserManager>();

            var user = await userManager.FindByNameAsync(context.UserName);
            if (user == null)
            {
                context.SetError("invalid_user", "The username or password is incorrect.");
                SaveUserLogin(context.UserName, context.Request.LocalIpAddress, false);
                return;
            }

            if (!await userManager.CheckPasswordAsync(user, PasswordHelper.EncryptPassword(context.Password, user.UserName)))
            {
                context.SetError("invalid_user", "The username or password is incorrect.");
                SaveUserLogin(context.UserName, context.Request.LocalIpAddress, false);

                return;
            }

            SaveUserLogin(context.UserName, context.Request.LocalIpAddress, true);

            await userManager.UpdateAsync(user);

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager);
            AuthenticationProperties properties = CreateProperties(user);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);

            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key.Replace(".", ""), property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        private static AuthenticationProperties CreateProperties(AuthIdentityUser identityUser)
        {
            var data = new Dictionary<string, string>
            {
                { "user_name", identityUser.UserName },
                { "email",identityUser.Email },
                { "user_id", identityUser.UserId.ToString() }
            };

            return new AuthenticationProperties(data);
        }

        private void SaveUserLogin(string userName, string ipAddress, bool isSuccessful)
        {
            using (var bal = new UserLoginBAL())
            {
                var login = new UserLogin()
                {
                    UserName = userName,
                    IPV4Address = ipAddress,
                    IsSuccessful = isSuccessful,
                    CreatedDate = DateTime.Now
                };

                bal.Save(login);
            }
        }
    }
}