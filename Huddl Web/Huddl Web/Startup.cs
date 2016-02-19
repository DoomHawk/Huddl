using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Huddl_Web.Startup))]
namespace Huddl_Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
