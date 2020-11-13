using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeBooks.Startup))]
namespace MeBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
