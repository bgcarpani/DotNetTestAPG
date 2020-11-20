using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PermissionsWebApp.Startup))]
namespace PermissionsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
