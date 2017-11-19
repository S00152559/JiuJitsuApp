using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JiuJitsuApp.Startup))]
namespace JiuJitsuApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
