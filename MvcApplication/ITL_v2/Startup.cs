using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITL_v2.Startup))]
namespace ITL_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
