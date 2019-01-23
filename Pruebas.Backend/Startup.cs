using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pruebas.Backend.Startup))]
namespace Pruebas.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
