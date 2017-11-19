using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JiuJitsuNotes.Startup))]
namespace JiuJitsuNotes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
