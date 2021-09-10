using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootballMatchHub.Startup))]
namespace FootballMatchHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
