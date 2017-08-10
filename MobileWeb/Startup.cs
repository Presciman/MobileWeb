using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileWeb.Startup))]
namespace MobileWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
