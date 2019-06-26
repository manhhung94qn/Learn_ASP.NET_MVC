using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MayTinhCaNhan.Startup))]
namespace MayTinhCaNhan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
