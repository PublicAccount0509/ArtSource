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
        private readonly IArtistBussinessLogic _artistBussinessLogic;
        private readonly IArtworkBussinessLogic _artworkBussinessLogic;
        private readonly IOrderBussinessLogic _orderBussinessLogic;
        public OrderController(IArtistBussinessLogic artistBussinessLogic, 
            IArtworkBussinessLogic artworkBussinessLogic,
            IOrderBussinessLogic orderBussinessLogic)
        {
            _artistBussinessLogic = artistBussinessLogic;
            _artworkBussinessLogic = artworkBussinessLogic;
            _orderBussinessLogic = orderBussinessLogic;
        }

        public ActionResult Test()
        {
            var model = new AddOrderModel();
            model.AuctionType = AuctionType.一口价;
            model.Price = 2000;
            model.ArtworkId = 1;
            model.CustomerId = 1;

            model.InvoiceType = InvoiceType.个人;
            model.InvoiceCompanyName = "微软公司";
            model.Note = "尽快发货啊";
            model.PackingType = PackingType.一般包装;
            model.ReceiptAddressId = 1;

            var order = AddOrderModelTranslator.Instance.Translate(model);

            var result = _orderBussinessLogic.AddOrder(order);
            return View();
        }


        public ActionResult List()
        {
            var criteria = new OrderSearchCriteria();
            criteria.PagingRequest = new WebExpress.Core.PagingRequest()
                {
                    PageIndex = 0,
                    PageSize = 10
                };

            var model = new OrderManageModel();
            model.PagedOrders = GetPagedOrderModel(criteria);
            return View(model);
        }

        [HttpPost]
        public PartialViewResult List(OrderSearchCriteria criteria)
        {
            var model = GetPagedOrderModel(criteria);
            return PartialView("_List", model);
        }

        private PagedOrderModel GetPagedOrderModel(OrderSearchCriteria criteria)
        {
            var pagedOrders = _orderBussinessLogic.SearchOrders(criteria);
            var simpleOrders = OrderSimpleModelTranslator.Instance.Translate(pagedOrders) as List<OrderSimpleModel>;
            var model = new PagedOrderModel(simpleOrders, pagedOrders.PagingResult);
            return model;
        }

        /// <summary>
        /// 接受
        /// </summary>
        [HttpPost]
        public JsonResult Accept(UpDateOrderModel model)
        {
            var order = _orderBussinessLogic.GetOrderById(model.Id);
            if (order == null)
            {
                return Json(new ResultModel(false, "无法找到请求的订单"));
            }
            if (order.Status != OrderStatus.待处理)
            {
                return Json(new ResultModel(false, "订单状态无法更改"));
            }
            order.Status = OrderStatus.已接受;
            _orderBussinessLogic.UpdateOrder(order);
            return Json(new ResultModel(true, string.Empty));
        }

        /// <summary>
        /// 拒绝
        /// </summary>
        [HttpPost]
        public JsonResult Refuse(UpDateOrderModel model)
        {
            if (string.IsNullOrEmpty(model.RefuseMessage))
            {
                return Json(new ResultModel(false, "拒绝原因必须输入"));
            }
            var order = _orderBussinessLogic.GetOrderById(model.Id);
            if (order == null)
            {
                return Json(new ResultModel(false, "无法找到请求的订单"));
            }
            if (order.Status != OrderStatus.待处理)
            {
                return Json(new ResultModel(false, "订单状态无法更改"));
            }
            order.Status = OrderStatus.已拒绝;
            order.RefuseMessage = model.RefuseMessage;
            _orderBussinessLogic.UpdateOrder(order);
            return Json(new ResultModel(true, string.Empty));
        }

        /// <summary>
        /// 退款
        /// </summary>
        [HttpPost]
        public JsonResult Refund(UpDateOrderModel model)
        {
            if (string.IsNullOrEmpty(model.RefundMessage))
            {
                return Json(new ResultModel(false, "退款原因必须输入"));
            }
            var order = _orderBussinessLogic.GetOrderById(model.Id);
            if (order == null)
            {
                return Json(new ResultModel(false, "无法找到请求的订单"));
            }
            if (order.Status != OrderStatus.已拒绝)
            {
                return Json(new ResultModel(false, "订单状态无法更改"));
            }
            order.Status = OrderStatus.已退款;
            order.RefundMessage = model.RefundMessage;
            _orderBussinessLogic.UpdateOrder(order);
            return Json(new ResultModel(true, string.Empty));
        }

        /// <summary>
        /// 等待发货
        /// </summary>
        public JsonResult Deliver(UpDateOrderModel model)
        {
            if (string.IsNullOrEmpty(model.DeliveryCompany))
            {
                return Json(new ResultModel(false, "物流公司不可为空"));
            }
            if (string.IsNullOrEmpty(model.DeliveryNumber))
            {
                return Json(new ResultModel(false, "物流单号不可为空"));
            }
            var order = _orderBussinessLogic.GetOrderById(model.Id);
            if (order == null)
            {
                return Json(new ResultModel(false, "无法找到请求的订单"));
            }
            if (order.Status != OrderStatus.已接受)
            {
                return Json(new ResultModel(false, "订单状态无法更改"));
            }
            order.DeliveryCompany = model.DeliveryCompany;
            order.DeliveryNumber = model.DeliveryNumber;
            order.Status = OrderStatus.已发货;
            _orderBussinessLogic.UpdateOrder(order);
            return Json(new ResultModel(true, string.Empty));
        }

        /// <summary>
        /// Auctions the list.
        /// </summary>
        /// <returns>
        /// ActionResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 9:56 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ActionResult AuctionList()
        {
            var criteria = new AuctionSearchCriteria
                {
                    PagingRequest = new WebExpress.Core.PagingRequest
                        {
                            PageIndex = 0,
                            PageSize = 10
                        }
                };

            var model = new AuctionManageModel
                {
                    PagedAuctions = GetPagedAuctionModel(criteria),
                    Artists = GetArtists(),
                    Artworks = GetArtworks()
                };
            return View(model);
        }

        /// <summary>
        /// Auctions the list.
        /// </summary>
        /// <param name="criteria">The criteria</param>
        /// <returns>
        /// PartialViewResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 11:36 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public PartialViewResult AuctionList(AuctionSearchCriteria criteria)
        {
            var model = GetPagedAuctionModel(criteria);
            return PartialView("_AuctionList", model);
        }


        /// <summary>
        /// 操作拍卖操作--接受
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// JsonResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 5:05 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public JsonResult AuctionAccept(int id)
        {
            System.Threading.Thread.Sleep(5000);
            var bussResult = _orderBussinessLogic.AuctionAccept(id);
            var result = new ResultModel(bussResult, "");
            return Json(result);
        }

        /// <summary>
        /// 操作拍卖操作--拒绝
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// JsonResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 6:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public JsonResult AuctionRefuse(int id)
        {
            var bussResult = _orderBussinessLogic.AuctionRefuse(id);
            var result = new ResultModel(bussResult, "");
            return Json(result);
        }

        /// <summary>
        /// Gets the paged auction model.
        /// </summary>
        /// <param name="criteria">The criteria</param>
        /// <returns>
        /// PagedAuctionModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 11:36 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private PagedAuctionModel GetPagedAuctionModel(AuctionSearchCriteria criteria)
        {
            var pagedOrders = _orderBussinessLogic.SearchAuction(criteria);
            //foreach (var item in pagedOrders)
            //{
            //    var simpleOrder = AuctionSimpleModelTranslator.Instance.Translate(item);
            //    simpleOrders.Add(simpleOrder);
            //}
            var simpleOrders =
                pagedOrders.Select(item => AuctionSimpleModelTranslator.Instance.Translate(item)).ToList();

            var model = new PagedAuctionModel(simpleOrders, pagedOrders.PagingResult);
            return model;
        }

        /// <summary>
        /// Gets the artists.
        /// </summary>
        /// <returns>
        /// IList{Art.Website.Models.ArtistModel}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 1:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<ArtistModel> GetArtists()
        {
            var artists = _artistBussinessLogic.GetArtists();
            return artists.Select(item => ArtistTranslator.Instance.Translate(item)).ToList();
        }

        /// <summary>
        /// Gets the artworks.
        /// </summary>
        /// <returns>
        /// List{ArtworkModel}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 1:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<ArtworkModel> GetArtworks()
        {
            var artworks = _artworkBussinessLogic.GetArtworks();
            return artworks.Select(item => ArtworkModelTranslator.Instance.Translate(item)).ToList();
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// The ActionResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/13/2014 2:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ActionResult Detail(int id)
        {
            var result = _orderBussinessLogic.GetOrderById(id);
            if (result == null)
            {
                return View(new OrderDetailModel());
            }
            var model = OrderDetailModelTranslator.Instance.Translate(result);
            var address = _orderBussinessLogic.GetAddress(result.ReceiptAddressId);
            if (address != null)
            {
                model.ReceiptAddress = AddressModelTranslator.Instance.Translate(address);
            }
            return View(model);
        }
    }
}
