namespace Ets.SingleApi.Caches
{
    using System;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.CacheServices;
    using Ets.SingleApi.Services.ICacheServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ShoppingCartCacheServices
    /// 命名空间：Ets.SingleApi.Caches
    /// 类功能：购物车缓存
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 8:52 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartCacheServices : IShoppingCartCacheServices
    {
        /// <summary>
        /// 取得餐厅信息
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCartSupplier> GetShoppingCartSupplier(int supplierId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}{1}", "shopping_cart_supplier", supplierId)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<ShoppingCartSupplier>
               {
                   StatusCode = (int)StatusCode.Succeed.Empty
               };
            }

            return new CacheServicesResult<ShoppingCartSupplier>
                {
                    Result = result.Deserialize<ShoppingCartSupplier>()
                };
        }

        /// <summary>
        /// 保存餐厅信息
        /// </summary>
        /// <param name="supplier">餐厅信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartSupplier(ShoppingCartSupplier supplier)
        {
            var supplierId = supplier.SupplierId;
            CacheUtility.GetInstance().Delete(string.Format("{0}{1}", "shopping_cart_supplier", supplierId));
            CacheUtility.GetInstance().Add(string.Format("{0}{1}", "shopping_cart_supplier", supplierId), supplier.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartLongCacheTime));
            return new CacheServicesResult<bool>
                {
                    Result = true
                };
        }

        /// <summary>
        /// 取得顾客信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCartCustomer> GetShoppingCartCustomer(int userId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}{1}", "shopping_cart_customer", userId)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<ShoppingCartCustomer>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty
                };
            }

            return new CacheServicesResult<ShoppingCartCustomer>
            {
                Result = result.Deserialize<ShoppingCartCustomer>()
            };
        }

        /// <summary>
        /// 保存顾客信息
        /// </summary>
        /// <param name="customer">顾客信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartCustomer(ShoppingCartCustomer customer)
        {
            var userId = customer.UserId;
            CacheUtility.GetInstance().Delete(string.Format("{0}{1}", "shopping_cart_customer", userId));
            CacheUtility.GetInstance().Add(string.Format("{0}{1}", "shopping_cart_customer", userId), customer.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartLongCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 取得订单信息
        /// </summary>
        /// <param name="id">订单唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCartOrder> GetShoppingCartOrder(string id)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}{1}", "shopping_cart_order", id)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<ShoppingCartOrder>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty
                };
            }

            return new CacheServicesResult<ShoppingCartOrder>
            {
                Result = result.Deserialize<ShoppingCartOrder>()
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="order">订单信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartOrder(ShoppingCartOrder order)
        {
            var id = order.Id;
            CacheUtility.GetInstance().Delete(string.Format("{0}{1}", "shopping_cart_order", id));
            CacheUtility.GetInstance().Add(string.Format("{0}{1}", "shopping_cart_order", id), order.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 取得购物车信息
        /// </summary>
        /// <param name="id">购物车唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCart> GetShoppingCart(string id)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}{1}", "shopping_cart", id)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<ShoppingCart>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty
                };
            }

            return new CacheServicesResult<ShoppingCart>
            {
                Result = result.Deserialize<ShoppingCart>()
            };
        }

        /// <summary>
        /// 保存购物车信息
        /// </summary>
        /// <param name="shoppingCart">购物车信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCart(ShoppingCart shoppingCart)
        {
            var shoppingCartId = shoppingCart.ShoppingCartId;
            CacheUtility.GetInstance().Delete(string.Format("{0}{1}", "shopping_cart", shoppingCartId));
            CacheUtility.GetInstance().Add(string.Format("{0}{1}", "shopping_cart", shoppingCartId), shoppingCart.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 获取购物车关联信息
        /// </summary>
        /// <param name="shoppingCartLinkId">购物车关联Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCartLink> GetShoppingCartLink(string shoppingCartLinkId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}{1}", "shopping_cart_link", shoppingCartLinkId)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<ShoppingCartLink>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty
                };
            }

            return new CacheServicesResult<ShoppingCartLink>
            {
                Result = result.Deserialize<ShoppingCartLink>()
            };
        }

        /// <summary>
        /// 保存购物车关联信息
        /// </summary>
        /// <param name="shoppingCartLink">购物车关联信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartLink(ShoppingCartLink shoppingCartLink)
        {
            var shoppingCartLinkId = shoppingCartLink.ShoppingCartLinkId;
            CacheUtility.GetInstance().Delete(string.Format("{0}{1}", "shopping_cart_link", shoppingCartLinkId));
            CacheUtility.GetInstance().Add(string.Format("{0}{1}", "shopping_cart_link", shoppingCartLinkId), shoppingCartLink.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            CacheUtility.GetInstance().Delete(string.Format("{0}{1}_{2}", "shopping_cart_link", shoppingCartLink.AnonymityId, shoppingCartLink.UserId));
            CacheUtility.GetInstance().Add(string.Format("{0}{1}_{2}", "shopping_cart_link", shoppingCartLink.AnonymityId, shoppingCartLink.UserId), shoppingCartLink.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }
    }
}