using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art.Website.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new SummaryModel();
            //model.ArtistCount = 100;
            //model.ArtworkCountLastest = 200;
            //model.ArtworkCountOffline = 300;
            //model.ArtworkCountOnline = 400;
            //model.ArtworkCountxxxxxxx = 500;
            //model.TransactionCountToday = 600;
            //model.TransactionCountTotal = 700;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
