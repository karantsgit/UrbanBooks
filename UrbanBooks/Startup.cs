using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UrbanBooks.Startup))]
namespace UrbanBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
