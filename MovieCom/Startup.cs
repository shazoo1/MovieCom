using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieCom.Startup))]
namespace MovieCom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
