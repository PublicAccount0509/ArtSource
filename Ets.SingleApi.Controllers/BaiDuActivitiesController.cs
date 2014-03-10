using System.Web.Http;
using Ets.SingleApi.Model.Controller;
using Ets.SingleApi.Utility;
using Ets.SingleApi.Controllers.IServices;

namespace Ets.SingleApi.Controllers
{
    /// <summary>
    /// 类名称：BaiDuActivitiesController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：3/7/2014 10:39 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiDuActivitiesController : SingleApiController
    {
        /// <summary>
        /// 字段smsServices
        /// </summary>
        /// 创建者：单琪彬
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISmsServices smsServices;

        /// <summary>
        /// 字段orderServices
        /// </summary>
        /// 创建者：单琪彬
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IOrderServices orderServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersController"/> class.
        /// </summary>
        /// <param name="smsServices"></param>
        /// <param name="orderServices">The orderServices</param>
        /// 创建者：单琪彬
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public BaiDuActivitiesController(ISmsServices smsServices,IOrderServices orderServices)
        {
            this.smsServices = smsServices;
            this.orderServices = orderServices;
        }
        /// <summary>
        /// 根据手机号获取优惠码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：12/20/2013 12:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<string> GetPreferentialCodeByMobile(string mobile)
        {
            return new Response<string>();
            //if (applicationId.IsEmptyOrNull())
            //{
            //    return new Response<string>
            //    {
            //        Message = new ApiMessage
            //        {
            //            StatusCode = (int)StatusCode.General.InvalidRequest
            //        },
            //        Result = string.Empty
            //    };
            //}

            //var getLightApplicationIdResult = this.baiDuLightServices.GetLightApplicationId(this.Source, applicationId);
            //if (getLightApplicationIdResult.Result == null)
            //{
            //    return new Response<string>
            //    {
            //        Message = new ApiMessage
            //        {
            //            StatusCode = getLightApplicationIdResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getLightApplicationIdResult.StatusCode
            //        },
            //        Result = string.Empty
            //    };
            //}

            //return new Response<string>
            //{
            //    Message = new ApiMessage
            //    {
            //        StatusCode = getLightApplicationIdResult.StatusCode
            //    },
            //    Result = getLightApplicationIdResult.Result
            //};
        }


    }
}
