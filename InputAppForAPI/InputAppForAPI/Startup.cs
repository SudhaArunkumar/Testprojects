using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InputAppForAPI.Startup))]
namespace InputAppForAPI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
