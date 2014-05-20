using Art.BussinessLogic;
using Art.Data.Common;
using Art.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebExpress.Core;

namespace Art.WebService.Controllers
{
    public class OrderController : ApiController
    {
        private IArtistBussinessLogic _artistBussinessLogic;
        private IArtworkBussinessLogic _artworkBussinessLogic;
        private ICustomerBussinessLogic _customerBussinessLogic;
        private IOrderBussinessLogic _orderBussinessLogic;
        public OrderController(IArtistBussinessLogic artistBussinessLogic,
            IArtworkBussinessLogic artworkBussinessLogic,
            ICustomerBussinessLogic customerBussinessLogic,
            IOrderBussinessLogic orderBussinessLogic)
        {
            _artistBussinessLogic = artistBussinessLogic;
            _artworkBussinessLogic = artworkBussinessLogic;
            _customerBussinessLogic = customerBussinessLogic;
            _orderBussinessLogic = orderBussinessLogic;
        }

        /// <summary>
        /// 放到购物车
        /// </summary>
        [ActionStatus(typeof(AddToShopCartStatus))]
        public IntResultModel AddToShopCart(AddToShopCartModel model)
        {
            if (!_artworkBussinessLogic.Exist(model.ArtworkId))
            {
                return IntResultModel.Conclude(AddToShopCartStatus.InvalidArtworkId);
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return IntResultModel.Conclude(AddToShopCartStatus.InvalidUserId);
            }

            var item = _orderBussinessLogic.GetShoppingCart(model.ArtworkId, model.UserId);
            if (item != null)
            {
                return IntResultModel.Conclude(AddToShopCartStatus.AlreadyAdded);
            }
            var result = _orderBussinessLogic.AddShoppingCartItem(model.ArtworkId, model.UserId);
            return IntResultModel.Conclude(AddToShopCartStatus.Success, result.Id);
        }

        /// <summary>
        /// 获取购物车商品列表
        /// </summary>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<MyShopCartItemModel[]> MyShopCart(GetToShopCartModel model)
        {
            var list = _orderBussinessLogic.GetShoppingCartItems(model.UserId);
            //var results = list.Select(p => MyShopCartModelTranslator.Instance.Translate(p)).ToArray();
            var results = MyShopCartModelTranslator.Instance.Translate(list).ToArray();
            return ResultModel<MyShopCartItemModel[]>.Conclude(StandaloneStatus.Success, results);
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<OrderDetailModel> Detail(int orderId)
        {
            var order = _orderBussinessLogic.GetOrderById(orderId);
            var result = OrderDetailModelTranslator.Instance.Translate(order);
            return ResultModel<OrderDetailModel>.Conclude(StandaloneStatus.Success, result);
        }

        /// 新增订单
        /// </summary>
        [ActionStatus(typeof(AddOrderStatus))]
        [HttpPost]
        public IntResultModel Add(AddOrderModel model)
        {
            if (!EnumExtenstion.OwnElement<AuctionType>(model.AuctionType))
            {
                return IntResultModel.Conclude(AddOrderStatus.InvalidAuctionType);
            }

            if (!EnumExtenstion.OwnElement<DeliveryType>(model.DeliveryType))
            {
                return IntResultModel.Conclude(AddOrderStatus.InvalidAuctionType);
            }

            if (!EnumExtenstion.OwnElement<InvoiceType>(model.InvoiceType))
            {
                return IntResultModel.Conclude(AddOrderStatus.InvalidInvoiceType);
            }

            if (!EnumExtenstion.OwnElement<PackingType>(model.PackingType))
            {
                return IntResultModel.Conclude(AddOrderStatus.InvalidPackingType);
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return IntResultModel.Conclude(AddOrderStatus.InvalidUserId);
            }

            if (_customerBussinessLogic.GetAddressById(model.ReceiptAddressId) == null)
            {
                return IntResultModel.Conclude(AddOrderStatus.InvalidAddressId);
            }

            var artwork = _artworkBussinessLogic.GetArtwork(model.ArtworkId);
            if (artwork == null)
            {
                return IntResultModel.Conclude(AddOrderStatus.InvalidArtworkId);
            }

            if (!artwork.IsPublic)
            {
                return IntResultModel.Conclude(AddOrderStatus.ArtworkUnPublished);
            }

            if (model.DeliveryType == DeliveryType.市内 && !artwork.FeeDeliveryLocal.HasValue)
            {
                return IntResultModel.Conclude(AddOrderStatus.NotSupportedDeliveryType);
            }
            else if (model.DeliveryType == DeliveryType.外地 && !artwork.FeeDeliveryNonlocal.HasValue)
            {
                return IntResultModel.Conclude(AddOrderStatus.NotSupportedDeliveryType);
            }

            if (model.PackingType == PackingType.一般包装 && !artwork.FeePackageGeneral.HasValue)
            {
                return IntResultModel.Conclude(AddOrderStatus.NotSupportedPackageType);
            }
            else if (model.PackingType == PackingType.精包装 && !artwork.FeePackageFine.HasValue)
            {
                return IntResultModel.Conclude(AddOrderStatus.NotSupportedPackageType);
            }

            var orders = _orderBussinessLogic.GetOrdersByArtworkId(model.ArtworkId);
            if (orders.Any(i => i.Status == Data.Common.OrderStatus.生成中 ||
                i.Status == Data.Common.OrderStatus.待处理 ||
                i.Status == Data.Common.OrderStatus.完成 ||
                i.Status == Data.Common.OrderStatus.已发货 ||
                i.Status == Data.Common.OrderStatus.已接受))
            {
                return IntResultModel.Conclude(AddOrderStatus.ArtworkPurchased);
            }

            var order = AddOrderModelTranslator.Instance.Translate(model);
            var result = _orderBussinessLogic.AddOrder(order);

            return IntResultModel.Conclude(AddOrderStatus.Success, result.Id);
        }
    }
}
