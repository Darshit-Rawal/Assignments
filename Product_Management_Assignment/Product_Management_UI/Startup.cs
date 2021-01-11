using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Product_Management_UI.Startup))]
namespace Product_Management_UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
