using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FastLearn.com.Startup))]
namespace FastLearn.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
