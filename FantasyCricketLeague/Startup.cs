using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FantasyCricketLeague.Startup))]
namespace FantasyCricketLeague
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
