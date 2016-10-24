using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hap.Startup))]
namespace Hap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
