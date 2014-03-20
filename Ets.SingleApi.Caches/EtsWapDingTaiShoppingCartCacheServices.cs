namespace Ets.SingleApi.Caches
{
    using System;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.CacheServices;
    using Ets.SingleApi.Services.ICacheServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：EtsWapDingTaiShoppingCartCacheServices
    /// 命名空间：Ets.SingleApi.Caches
    /// 类功能：购物车缓存
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 8:52 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapDingTaiShoppingCartCacheServices : IEtsWapDingTaiShoppingCartCacheServices
    {
        /// <summary>
        /// 取得餐厅信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCartSupplier> GetShoppingCartSupplier(string source, int supplierId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "shopping_cart_supplier", supplierId)) as string;
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
        /// <param name="source">The source</param>
        /// <param name="supplier">餐厅信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartSupplier(string source, ShoppingCartSupplier supplier)
        {
            var supplierId = supplier.SupplierId;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, "shopping_cart_supplier", supplierId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}", source, "shopping_cart_supplier", supplierId), supplier.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartLongCacheTime));
            return new CacheServicesResult<bool>
                {
                    Result = true
                };
        }

        /// <summary>
        /// 取得顾客信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCartCustomer> GetShoppingCartCustomer(string source, int userId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "shopping_cart_customer", userId)) as string;
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
        /// <param name="source">The source</param>
        /// <param name="customer">顾客信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartCustomer(string source, ShoppingCartCustomer customer)
        {
            var userId = customer.UserId;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, "shopping_cart_customer", userId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}", source, "shopping_cart_customer", userId), customer.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartLongCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 取得订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<EtsWapDingTaiShoppingCartOrder> GetShoppingCartOrder(string source, string id)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "shopping_cart_order", id)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<EtsWapDingTaiShoppingCartOrder>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty
                };
            }

            return new CacheServicesResult<EtsWapDingTaiShoppingCartOrder>
            {
                Result = result.Deserialize<EtsWapDingTaiShoppingCartOrder>()
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="order">订单信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartOrder(string source, EtsWapDingTaiShoppingCartOrder order)
        {
            var id = order.Id;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, "shopping_cart_order", id));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}", source, "shopping_cart_order", id), order.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 取得购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<EtsWapDingTaiShoppingCart> GetShoppingCart(string source, string id)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "shopping_cart", id)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<EtsWapDingTaiShoppingCart>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty
                };
            }

            return new CacheServicesResult<EtsWapDingTaiShoppingCart>
            {
                Result = result.Deserialize<EtsWapDingTaiShoppingCart>()
            };
        }

        /// <summary>
        /// 保存购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCart">购物车信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCart(string source, EtsWapDingTaiShoppingCart shoppingCart)
        {
            var shoppingCartId = shoppingCart.ShoppingCartId;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, "shopping_cart", shoppingCartId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}", source, "shopping_cart", shoppingCartId), shoppingCart.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }
        /// <summary>
        /// 获取订单配送信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单配送信息唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCartDelivery> GetShoppingCartDelivery(string source, string id)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "shopping_cart_delivery", id)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<ShoppingCartDelivery>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty
                };
            }

            return new CacheServicesResult<ShoppingCartDelivery>
            {
                Result = result.Deserialize<ShoppingCartDelivery>()
            };
        }

        /// <summary>
        /// 获取订单台位信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单台位信息唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 11:03 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCartDesk> GetShoppingCartDesk(string source, string id)
        {
            var result =
                CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "shopping_cart_desk", id)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<ShoppingCartDesk>
                    {
                        StatusCode = (int) StatusCode.Succeed.Empty
                    };
            }

            return new CacheServicesResult<ShoppingCartDesk>
                {
                    Result = result.Deserialize<ShoppingCartDesk>()
                };
        }

        /// <summary>
        /// 保存订单配送信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartDelivery">订单配送信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartDelivery(string source, ShoppingCartDelivery shoppingCartDelivery)
        {
            var id = shoppingCartDelivery.Id;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, "shopping_cart_delivery", id));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}", source, "shopping_cart_delivery", id), shoppingCartDelivery.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 保存订单台位信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartDesk">订单台位信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 11:36 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 11:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartDesk(string source, ShoppingCartDesk shoppingCartDesk)
        {
            var id = shoppingCartDesk.Id;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, "shopping_cart_desk", id));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}", source, "shopping_cart_desk", id), shoppingCartDesk.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 获取购物车关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartLinkId">购物车关联Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<EtsWapDingTaiShoppingCartLink> GetShoppingCartLink(string source, string shoppingCartLinkId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "shopping_cart_link", shoppingCartLinkId)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<EtsWapDingTaiShoppingCartLink>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty
                };
            }

            return new CacheServicesResult<EtsWapDingTaiShoppingCartLink>
            {
                Result = result.Deserialize<EtsWapDingTaiShoppingCartLink>()
            };
        }

        /// <summary>
        /// 保存购物车关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartLink">购物车关联信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/18/2014 9:14 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartLink(string source, EtsWapDingTaiShoppingCartLink shoppingCartLink)
        {
            var shoppingCartLinkId = shoppingCartLink.ShoppingCartLinkId;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, "shopping_cart_link", shoppingCartLinkId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}", source, "shopping_cart_link", shoppingCartLinkId), shoppingCartLink.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}_{3}", source, "shopping_cart_link", shoppingCartLink.AnonymityId, shoppingCartLink.SupplierId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}_{3}", source, "shopping_cart_link", shoppingCartLink.AnonymityId, shoppingCartLink.SupplierId), shoppingCartLink.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }
    }
}