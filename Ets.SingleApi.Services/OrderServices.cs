namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 类名称：OrderServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订单功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 6:16 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OrderServices : IOrderServices
    {
        /// <summary>
        /// 添加一个外卖订单
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 6:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> AddWaiMaiOrder(AddWaiMaiOrderParameter parameter)
        {
            return new ServicesResult<bool>();
        }
    }
}