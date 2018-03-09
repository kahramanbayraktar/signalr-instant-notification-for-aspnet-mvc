using System.Configuration;

namespace AspNetMvcSignalRNotification.Helpers
{
    public class Constants
    {
        public const string CurrentUserEmail = "user@domain.com";

        public static string UserCookieName => ConfigurationManager.AppSettings["UserCookieName"];
    }
}