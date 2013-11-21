namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.ICacheServices;

    /// <summary>
    /// 类名称：ShoppingCartServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 12:17 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartServices : IShoppingCartServices
    {
        /// <summary>
        /// 字段shoppingCartCacheServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartCacheServices shoppingCartCacheServices;

        /// <summary>
        /// 字段shoppingCartBusinessServiceList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IShoppingCartBusinessService> shoppingCartBusinessServiceList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartServices"/> class.
        /// </summary>
        /// <param name="shoppingCartCacheServices">The shoppingCartCacheServices</param>
        /// <param name="shoppingCartBusinessServiceList">The shoppingCartBusinessServiceList</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartServices(
            IShoppingCartCacheServices shoppingCartCacheServices,
            List<IShoppingCartBusinessService> shoppingCartBusinessServiceList)
        {
            this.shoppingCartCacheServices = shoppingCartCacheServices;
            this.shoppingCartBusinessServiceList = shoppingCartBusinessServiceList;
        }

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
        public ServicesResult<ShoppingCart> Create(int type, int businessId, int? userId)
        {
            var shoppingCartCacheResult = this.shoppingCartCacheServices.GetShoppingCartBusiness(type, businessId);
            if (shoppingCartCacheResult == null)
            {
                
            }
            return new ServicesResult<ShoppingCart>();
        }
    }
}