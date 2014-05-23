using Ets.SingleApi.Model.ExternalServices;

namespace Ets.SingleApi.Services.IExternalServices
{
    /// <summary>
    /// 类名称：ISingleApiOrdersExternalService
    /// 命名空间：Ets.SingleApi.Services.IExternalServices
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/28/2014 5:01 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ISingleApiOrdersExternalService
    {
        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="urlParameter">Url参数</param>
        /// <param name="data">请求数据</param>
        /// <param name="authenParameter">权限参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：12/6/2013 9:42 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ExternalServiceResult OrderNumber(IExternalUrlParameter urlParameter, string data, SingleApiExternalServiceAuthenParameter authenParameter);
    }
}
