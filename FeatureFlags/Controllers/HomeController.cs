using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeatureFlags.Features;

namespace FeatureFlags.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Feature.Enabled<CurrentTimeFeature>())
            {
                ViewBag.Message = "Now showing current time";
            }
            else
                ViewBag.Message = "Current Time is not enabled";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CurrentTime()
        {
            return PartialView();
        }
    }
}
