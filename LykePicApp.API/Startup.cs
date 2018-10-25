using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LykePicApp.API.Startup))]
namespace LykePicApp.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}