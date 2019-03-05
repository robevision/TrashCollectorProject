using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trash_Collector_Project.Startup))]
namespace Trash_Collector_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
