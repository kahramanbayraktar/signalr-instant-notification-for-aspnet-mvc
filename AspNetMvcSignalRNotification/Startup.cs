using Owin;

namespace AspNetMvcSignalRNotification
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}