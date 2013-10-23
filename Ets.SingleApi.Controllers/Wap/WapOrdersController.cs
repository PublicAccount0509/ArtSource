namespace Ets.SingleApi.Controllers.Wap
{
    using System.Collections.Generic;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;

    using System.Web.Http;
    using System.Linq;

    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：WapOrdersController
    /// 命名空间：Ets.SingleApi.Controllers.Wap
    /// 类功能：订单功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 5:20 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WapOrdersController : ApiController
    {
        /// <summary>
        /// 字段orderServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IOrderServices orderServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="WapOrdersController"/> class.
        /// </summary>
        /// <param name="orderServices">The orderServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WapOrdersController(IOrderServices orderServices)
        {
            this.orderServices = orderServices;
        }

        [HttpGet]
        public string Test()
        {
            return "测试";
        }
        /// <summary>
        /// 添加一个外卖订单
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// WaiMaiOrderResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 6:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public WaiMaiOrderResponse WaiMaiOrder(WaiMaiOrderRequst requst)
        {
            if (requst == null)
            {
                return new WaiMaiOrderResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    },
                    Result = new WaiMaiOrderResult()
                };
            }

            var dishList = requst.DishList ?? new List<AddWaiMaiOrderDish>();
            var addWaiMaiOrderResult = this.orderServices.AddWaiMaiOrder(new AddWaiMaiOrderParameter
            {
                UserId = requst.UserId,
                DeliveryMethodId = requst.DeliveryMethodId,
                SupplierId = requst.SupplierId,
                DishList = dishList.Select(p => new AddWaiMaiOrderDishModel
                    {
                        SupplierDishId = p.SupplierDishId,
                        Quantity = p.Quantity
                    }).ToList()
            });

            var result = addWaiMaiOrderResult.Result ?? new AddWaiMaiOrderModel();
            return new WaiMaiOrderResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = addWaiMaiOrderResult.StatusCode
                },
                Result = new WaiMaiOrderResult
                    {
                        OrderId = result.OrderId,
                        CustomerTotal = result.CustomerTotal,
                        SupplierId = result.SupplierId,
                        SupplierName = result.SupplierName,
                        SupplierDishCount = result.SupplierDishCount
                    }
            };
        }
    }
}