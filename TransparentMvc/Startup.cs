using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TransparentMvc.Startup))]
namespace TransparentMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
