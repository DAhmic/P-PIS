using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmaceutskaKuca.Startup))]
namespace FarmaceutskaKuca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
