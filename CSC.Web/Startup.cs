using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSC.Web.Startup))]
namespace CSC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
