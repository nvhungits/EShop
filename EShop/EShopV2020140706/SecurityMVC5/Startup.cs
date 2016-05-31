using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecurityMVC5.Startup))]
namespace SecurityMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
