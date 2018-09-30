using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BICTCar.Startup))]
namespace BICTCar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
