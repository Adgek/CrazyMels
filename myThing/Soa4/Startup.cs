using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Soa4.Startup))]
namespace Soa4
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
