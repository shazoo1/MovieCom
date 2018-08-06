using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieCom.Web.Startup))]
namespace MovieCom.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
