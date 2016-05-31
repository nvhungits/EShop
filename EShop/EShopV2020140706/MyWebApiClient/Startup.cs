using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWebApiClient.Startup))]
namespace MyWebApiClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
