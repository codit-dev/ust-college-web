using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UphiweSkills.Startup))]
namespace UphiweSkills
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
