using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IS403_Project1.Startup))]
namespace IS403_Project1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
