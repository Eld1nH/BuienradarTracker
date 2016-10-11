using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Buienradar_Tracker.Startup))]
namespace Buienradar_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
