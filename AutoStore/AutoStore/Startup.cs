using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoStore.Startup))]
namespace AutoStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
