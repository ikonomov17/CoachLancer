using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoachLancer.Web.Startup))]
namespace CoachLancer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
