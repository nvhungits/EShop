using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EShopV2020140706.Startup))]
namespace EShopV2020140706
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
