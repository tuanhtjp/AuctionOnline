using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuctionOnline.Startup))]
namespace AuctionOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
