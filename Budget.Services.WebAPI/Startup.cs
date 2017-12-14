using Microsoft.Owin;
using Owin;
using Budget.Services.WebAPI;

[assembly: OwinStartup(typeof(Startup))]

namespace Budget.Services.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
