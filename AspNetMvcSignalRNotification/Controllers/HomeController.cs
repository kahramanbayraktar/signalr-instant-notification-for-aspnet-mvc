using AspNetMvcSignalRNotification.Helpers;
using AspNetMvcSignalRNotification.Hubs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;

namespace AspNetMvcSignalRNotification.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult _MyAction(int id)
        {
            var myEntity = GetEntityFromDb(id);

            if (myEntity == null)
                return Json(new { success = false, message = "Entity not found." }, JsonRequestBehavior.AllowGet);

            Thread.Sleep(2000);

            var done = DoSomeWork();

            if (done)
            {
                var recipients = AccountHelper.GetCurrentUser();
                NotificationHub.PushNotification(
                    new List<string> { recipients },
                    $"<a href='/someurl'>Task #{id} hast just been completed by {AccountHelper.GetCurrentUser()}</a>");

                return Json(new { success = true, message = $"Task #{id} done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = $"Task #{id} failed" }, JsonRequestBehavior.AllowGet);
        }

        private bool DoSomeWork()
        {
            return true;
        }

        private object GetEntityFromDb(int itemId)
        {
            return new Object();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}