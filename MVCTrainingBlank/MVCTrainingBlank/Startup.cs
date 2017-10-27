using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTrainingBlank.Startup))]
namespace MVCTrainingBlank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
