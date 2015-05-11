using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Helpify_v3.Startup))]
namespace Helpify_v3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
