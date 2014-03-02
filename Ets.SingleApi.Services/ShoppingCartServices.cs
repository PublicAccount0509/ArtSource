namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.ICacheServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ShoppingCartServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车基本信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/15/2013 1:29 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartServices : IShoppingCartServices
    {
        /// <summary>
        /// 字段shoppingCartBaseCacheServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/2/2014 5:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartBaseCacheServices shoppingCartBaseCacheServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartServices"/> class.
        /// </summary>
        /// <param name="shoppingCartBaseCacheServices">The shoppingCartBaseCacheServices</param>
        /// 创建者：周超
        /// 创建日期：3/2/2014 5:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartServices(IShoppingCartBaseCacheServices shoppingCartBaseCacheServices)
        {
            this.shoppingCartBaseCacheServices = shoppingCartBaseCacheServices;
        }

        /// <summary>
        /// 更改购物车状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">The shoppingCartId</param>
        /// <param name="complete">The  complete indicates whether</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartComplete(string source, string shoppingCartId, bool complete)
        {
            var result = this.shoppingCartBaseCacheServices.SaveShoppingCartComplete(source, shoppingCartId, complete);
            if (result == null)
            {
                return new ServicesResult<bool>
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidShoppingCartIdCode
                    };
            }

            return new ServicesResult<bool>
                {
                    Result = result.Result,
                    StatusCode = result.StatusCode
                };
        }

        /// <summary>
        /// 取得购物车基本信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">The shoppingCartId</param>
        /// <returns>
        /// 返回购物车基本信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartBase> GetShoppingCartBase(string source, string shoppingCartId)
        {
            var result = this.shoppingCartBaseCacheServices.GetShoppingCartBase(source, shoppingCartId);
            if (result == null)
            {
                return new ServicesResult<ShoppingCartBase>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidShoppingCartIdCode
                };
            }

            return new ServicesResult<ShoppingCartBase>
            {
                Result = result.Result,
                StatusCode = result.StatusCode
            };
        }

        /// <summary>
        /// 取得购物车Id
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回购物车Id
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetShoppingCartId(string source, int orderId)
        {
            var result = this.shoppingCartBaseCacheServices.GetShoppingCartId(source, orderId);
            if (result == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.NotFondShoppingCartCode
                };
            }

            return new ServicesResult<string>
            {
                Result = result.Result,
                StatusCode = result.StatusCode
            };
        }
    }
}