using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMWebApplication.Startup))]
namespace DMWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
