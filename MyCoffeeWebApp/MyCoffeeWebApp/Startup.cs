using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCoffeeWebApp.Startup))]
namespace MyCoffeeWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
