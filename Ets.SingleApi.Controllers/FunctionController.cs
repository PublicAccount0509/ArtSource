namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：FunctionController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：提供一些公用方法控制器
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/15/2013 1:13 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FunctionController : SingleApiController
    {
        /// <summary>
        /// 字段functionServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IFunctionServices functionServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionController"/> class.
        /// </summary>
        /// <param name="functionServices">The functionServices</param>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public FunctionController(IFunctionServices functionServices)
        {
            this.functionServices = functionServices;
        }

        /// <summary>
        /// 根据地址取得对应坐标
        /// </summary>
        /// <param name="address">楼宇地址</param>
        /// <param name="city">当前城市</param>
        /// <param name="type">定位类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<Location> Location(string address, string city = null, int? type = 0)
        {
            var getLocationResult = this.functionServices.GetLocation(this.Source, address, city ?? string.Empty, type ?? 0);
            if (getLocationResult.Result == null)
            {
                return new Response<Location>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getLocationResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getLocationResult.StatusCode
                    },
                    Result = new Location()
                };
            }

            return new Response<Location>
            {
                Message = new ApiMessage
                {
                    StatusCode = getLocationResult.StatusCode
                },
                Result = getLocationResult.Result
            };
        }
    }
}