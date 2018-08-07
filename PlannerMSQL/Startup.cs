using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlannerMSQL.Startup))]
namespace PlannerMSQL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
