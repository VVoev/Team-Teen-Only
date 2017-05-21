using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StupidChessBase.Startup))]
namespace StupidChessBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
