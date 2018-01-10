using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalityAppWeb.Startup))]
namespace PersonalityAppWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
