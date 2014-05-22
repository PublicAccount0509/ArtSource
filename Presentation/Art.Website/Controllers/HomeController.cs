using Art.BussinessLogic;
using Art.Data.Common;
using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core;

namespace Art.Website.Controllers
{

    public class HomeController : Controller
    {
        private readonly IArtistBussinessLogic _artistBussinessLogic;
        private readonly IArtworkBussinessLogic _artworkBussinessLogic;
        private readonly IOrderBussinessLogic _orderBussinessLogic;
        public HomeController(IArtistBussinessLogic artistBussinessLogic, 
            IArtworkBussinessLogic artworkBussinessLogic,
            IOrderBussinessLogic orderBussinessLogic)
        {
            _artistBussinessLogic = artistBussinessLogic;
            _artworkBussinessLogic = artworkBussinessLogic;
            _orderBussinessLogic = orderBussinessLogic;
        }

        public ActionResult Index()
        {
            var allArtist = _artistBussinessLogic.GetArtists();
            var allArtwork = _artworkBussinessLogic.GetArtworks();
            var allorder = _orderBussinessLogic.GetOrders();
            var model = new SummaryModel
                {
                    ArtistCount = allArtist.Count,
                    ArtistCountOnline = allArtist.Count(p => p.IsPublic),
                    ArtistCountOffline = allArtist.Count(p => !p.IsPublic),
                    ArtworkCountNewWeek = allArtwork.Count(p => p.FADateTime >= DateTime.Now.AddDays(-7).BeginOfDay()),
                    ArtworkCount = allArtwork.Count,
                    ArtworkCountOffline = allArtwork.Count(p => !p.IsPublic),
                    ArtworkCountOnline = allArtwork.Count(p => p.IsPublic),
                    TransactionCountToday =
                        allorder.Count(p =>
                            p.PayStatus == PayStatus.支付成功 &&
                            p.FADateTime.ToShortDateString() == DateTime.Now.ToShortDateString()),
                    TransactionCountTotal = allorder.Count(p => p.PayStatus == PayStatus.支付成功)
                };

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
