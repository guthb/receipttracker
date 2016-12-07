using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReceiptTracker.Startup))]
namespace ReceiptTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
