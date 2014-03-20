
using System.Collections.Generic;
using Ets.SingleApi.Model.Services;

namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;
    using Ets.SingleApi.Controllers.Filters;

    /// <summary>
    /// 类名称：OrdersController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：订台业务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/31/2013 9:00 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DingTaiController : SingleApiController
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
        /// Initializes a new instance of the <see cref="OrdersController"/> class.
        /// </summary>
        /// <param name="orderServices">The orderServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DingTaiController(IOrderServices orderServices)
        {
            this.orderServices = orderServices;
        }

        /// <summary>
        /// 订台检索
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="searchDate">检索日期</param>
        /// <param name="searchTime">检索时间</param>
        /// <param name="searchPeopleNumber">检索人数</param>
        /// <param name="pageSize">每页最大数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// ListResponse{DingTaiSearchResult}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：3/19/2014 5:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        [TokenFilter]
        public ListResponse<DingTaiSearchResult> DingTaiSearch(int supplierId, string searchDate, string searchTime, int searchPeopleNumber, int? pageSize, int? pageIndex)
        {
            var list = new List<DingTaiSearchResult>
                {
                    new DingTaiSearchResult
                        {
                            RoomTypeId = 0,
                            RoomTypeName = "散座",
                            TableTypeName = "小桌",
                            MinNumber = "1",
                            MaxNumber = "6",
                            DepositAmount = "300.00"
                        },
                    new DingTaiSearchResult
                        {
                            RoomTypeId = 0,
                            RoomTypeName = "散座",
                            TableTypeName = "小桌",
                            MinNumber = "1",
                            MaxNumber = "4",
                            DepositAmount = "200.00"
                        },
                    new DingTaiSearchResult
                        {
                            RoomTypeId = 1,
                            RoomTypeName = "包房",
                            TableTypeName = "中桌",
                            MinNumber = "4",
                            MaxNumber = "10",
                            DepositAmount = "500.00"
                        }
                };

            //return new ListResponse<IOrderModel>
            //{
            //    Message = new ApiMessage
            //    {
            //        StatusCode = list.StatusCode
            //    },
            //    ResultTotalCount = list.ResultTotalCount,
            //    Result = result
            //};
            return new ListResponse<DingTaiSearchResult>
            {
                Message = new ApiMessage
                {
                    StatusCode = (int)StatusCode.Succeed.Ok
                },
                ResultTotalCount = list.Count,
                Result = list
            };
        }
    }
}