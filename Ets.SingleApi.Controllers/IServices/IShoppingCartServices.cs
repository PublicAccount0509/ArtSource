namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IShoppingCartServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：购物车服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 11:49 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IShoppingCartServices
    {
        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="type">购物车类型</param>
        /// <param name="businessId">商家Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回一个购物车
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<ShoppingCartModel> Create(int type, int businessId, int? userId);
    }
}