using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AM7HackkthonAppService.Startup))]

namespace AM7HackkthonAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}