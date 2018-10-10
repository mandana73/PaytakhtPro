[assembly: Microsoft.Owin.OwinStartup(typeof(BICT.Payetakht.Startup))]

namespace BICT.Payetakht
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
