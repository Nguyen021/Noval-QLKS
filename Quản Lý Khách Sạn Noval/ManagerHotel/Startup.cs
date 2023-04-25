using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagerHotel.Startup))]
namespace ManagerHotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
