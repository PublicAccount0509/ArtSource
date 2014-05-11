using Art.BussinessLogic;
using Art.BussinessLogic.Entities;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art.Website.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Test()
        {
            var model = new AddOrderModel();
            model.ArtworkId = 1;
            model.CustomerId = 1;
            model.DeliveryMode = DeliveryMode.自提;
            model.InvoiceType = InvoiceType.个人;
            model.InvoiceCustomerName = "雷锋";
            model.Message = "sssssssoon";
            model.PayMode = PayMode.Alipay;

            var order = AddOrderModelTranslator.Instance.Translate(model);

            var orders = new List<Order> { order };
            var result = OrderBussinessLogic.Instance.AddOrders(orders);
            var model2 = new OrderManageModel();
            return View(model2);
        }


        public ActionResult List()
        {
            var criteria = new OrderSearchCriteria();
            criteria.PagingRequest = new WebExpress.Core.PagingRequest()
            {
                PageIndex = 0,
                PageSize = 10
            };
            var pagedOrders = OrderBussinessLogic.Instance.SearchOrders(criteria);
            var simpleOrders = new List<OrderSimpleModel>();
            foreach (var item in pagedOrders)
            {
                var simpleOrder = OrderSimpleModelTranslator.Instance.Translate(item);
                simpleOrders.Add(simpleOrder);
            }
            var model = new OrderManageModel();
            model.PagedOrders = new PagedOrderSimpleModel(simpleOrders, pagedOrders.PagingResult);
            return View(model);
        }

        public ActionResult AuctionList() 
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
