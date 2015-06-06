using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Argo.Startup))]
namespace Argo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
