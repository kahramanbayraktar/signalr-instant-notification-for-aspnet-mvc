using System;
using System.Web;

namespace AspNetMvcSignalRNotification.Helpers
{
    public class AccountHelper
    {
        public static string GetCurrentUser()
        {
            return Constants.CurrentUserEmail; // HttpContext.Current.Request.Cookies[Constants.UserCookieName]?.Value;
        }

        public static void SetCurrentUser(string email)
        {
            var cookie = new HttpCookie(Constants.UserCookieName, email)
            {
                Expires = DateTime.Now.AddMinutes(1440),
                HttpOnly = true
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}