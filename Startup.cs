using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyDynastyHomesAuth.Startup))]
namespace MyDynastyHomesAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
