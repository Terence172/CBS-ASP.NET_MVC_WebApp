using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_3_ASP.NET_MVC_CRUD.Startup))]
namespace Assignment_3_ASP.NET_MVC_CRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
