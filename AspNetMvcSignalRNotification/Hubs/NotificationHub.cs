using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcSignalRNotification.Hubs
{
    public class NotificationHub : Hub
    {
        public static List<KeyValuePair<string, string>> Recipients = new List<KeyValuePair<string, string>>();

        public static void PushNotification(List<string> recipients, string message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

            bool selector(KeyValuePair<string, string> s) => recipients.Contains(s.Key);
            //Func<KeyValuePair<string, string>, bool> selector = s => recipients.Contains(s.Value);
            var connectionIds = Recipients.Where(selector).Select(y => y.Value).ToList();

            hubContext.Clients.All.DisplayNotification(message);
            //hubContext.Clients.Clients(connectionIds).DisplayNotification(title, url);
        }

        public override Task OnConnected()
        {
            var userId = Helpers.AccountHelper.GetCurrentUser(); // Context.User.Identity.Name;
            Recipients.Add(new KeyValuePair<string, string>(userId, Context.ConnectionId));

            return base.OnConnected();
        }
    }
}