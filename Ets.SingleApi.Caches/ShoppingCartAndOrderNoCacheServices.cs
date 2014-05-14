namespace Ets.SingleApi.Caches
{
    using System;
    using Ets.SingleApi.Utility;
    using Ets.SingleApi.Model.CacheServices;
    using Ets.SingleApi.Services.ICacheServices;
    /// <summary>
    /// 类名称：ShoppingCartAndOrderNoCacheServices
    /// 命名空间：Ets.SingleApi.Caches
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/12/2014 5:01 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartAndOrderNoCacheServices : IShoppingCartAndOrderNoCacheServices
    {
        /// <summary>
        /// 保存订单编号和购物车编号对应关系
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId"></param>
        /// <param name="shoppingcartId"></param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartAndOrderNoLink(string source, string orderId, string shoppingcartId)
        {
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, "shopping_cart_orderIdAndShoppingcartId", orderId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}", source, "shopping_cart_orderIdAndShoppingcartId", orderId), shoppingcartId, DateTime.Now.AddHours(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }


        /// <summary>
        /// 根据订单编号查询对应购物车编号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回购物车编号
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/12/2014 5:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<string> GetShoppingCartIdByOrderId(string source, string orderId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "shopping_cart_orderIdAndShoppingcartId", orderId)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.NotFondShoppingCartCode
                };
            }

            return new CacheServicesResult<string>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = result
            };
        }
    }
}
