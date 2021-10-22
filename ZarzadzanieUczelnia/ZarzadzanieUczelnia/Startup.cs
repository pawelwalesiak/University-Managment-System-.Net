using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZarzadzanieUczelnia.Startup))]
namespace ZarzadzanieUczelnia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
