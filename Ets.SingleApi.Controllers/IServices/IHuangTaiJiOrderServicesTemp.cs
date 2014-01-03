namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IHuangTaiJiOrderServicesTemp
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：黄太极订单功能
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：10/22/2013 6:05 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IHuangTaiJiOrderServicesTemp
    {
        /// <summary>
        /// 取得外卖订单详情
        /// </summary>
        /// <param name="orderId">The orderId</param>
        /// <param name="userId">The userId</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<HuangTaiJiWaiMaiOrderDetailModel> GetWaiMaiOrder(int orderId, int userId);

    }
}