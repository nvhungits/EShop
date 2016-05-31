using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UploadToDb.Startup))]
namespace UploadToDb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
