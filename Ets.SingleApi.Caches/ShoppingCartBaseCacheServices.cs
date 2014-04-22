namespace Ets.SingleApi.Caches
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Utility;
    using Ets.SingleApi.Model.CacheServices;
    using Ets.SingleApi.Services.ICacheServices;

    /// <summary>
    /// 类名称：ShoppingCartBaseCacheServices
    /// 命名空间：Ets.SingleApi.Caches
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/12/2014 5:01 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartBaseCacheServices : IShoppingCartBaseCacheServices
    {
        /// <summary>
        /// 保存订单编号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId"></param>
        /// <param name="shoppingCartId"></param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartId(string source, int orderId, string shoppingCartId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", shoppingCartId)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.EmptyShoppingCartCode
                };
            }

            var shoppingCartBase = result.Deserialize<ShoppingCartBase>();
            shoppingCartBase.OrderNumber = orderId;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", shoppingCartId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", shoppingCartId), shoppingCartBase.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, "base_shoppingcart_Id", orderId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}{2}", source, "base_shoppingcart_Id", orderId), shoppingCartId, DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartLongCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">The shoppingCartId</param>
        /// <param name="complete">The  complete indicates whether</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<bool> SaveShoppingCartComplete(string source, string shoppingCartId, bool complete)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", shoppingCartId)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.EmptyShoppingCartCode
                };
            }

            var shoppingCartBase = result.Deserialize<ShoppingCartBase>();
            shoppingCartBase.IsComplete = complete;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", shoppingCartId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", shoppingCartId), shoppingCartBase.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return new CacheServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 获取购物车基本信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">The shoppingCartId</param>
        /// <returns>
        /// 返回购物车基本信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/2/2014 3:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<ShoppingCartBase> GetShoppingCartBase(string source, string shoppingCartId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", shoppingCartId)) as string;
            if (result.IsEmptyOrNull())
            {
                return new CacheServicesResult<ShoppingCartBase>
                {
                    StatusCode = (int)StatusCode.Validate.EmptyShoppingCartCode,
                    Result = new ShoppingCartBase()
                };
            }

            var shoppingCartBase = result.Deserialize<ShoppingCartBase>();
            return new CacheServicesResult<ShoppingCartBase>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = shoppingCartBase
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
        /// 创建者：周超
        /// 创建日期：2/12/2014 5:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<string> GetShoppingCartId(string source, int orderId)
        {
            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "base_shoppingcart_Id", orderId)) as string;
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

        /// <summary>
        /// 绑定一个购物车编号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="userId">The userId</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回购物车编号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/12/2014 5:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CacheServicesResult<BindShoppingCartResult> BindShoppingCartId(string source, string supplierId, string userId, int orderId)
        {
            var shoppingCartId = string.Empty;
            if (orderId > 0)
            {
                shoppingCartId = (CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, "base_shoppingcart_Id", orderId)) as string) ?? string.Empty;
            }

            var shoppingCartIdResult = CacheUtility.GetInstance().Get(string.Format("{0}_{1}_{2}_{3}", source, "base_shoppingcart_Id", supplierId, userId)) as string;
            var shoppingCartIdDictionary = shoppingCartIdResult.Deserialize<Dictionary<string, bool>>() ?? new Dictionary<string, bool>();
            var lastShoppingCartId = shoppingCartIdDictionary.Where(p => p.Value).Select(p => p.Key).FirstOrDefault() ?? string.Empty;
            if (shoppingCartId.IsEmptyOrNull())
            {
                shoppingCartId = lastShoppingCartId;
            }

            if (!shoppingCartIdDictionary.ContainsKey(shoppingCartId))
            {
                var tempShoppingCartId = this.GetShoppingCartId(source);
                shoppingCartIdDictionary.Add(tempShoppingCartId, true);
                CacheUtility.GetInstance().Delete(string.Format("{0}_{1}_{2}_{3}", source, "base_shoppingcart_Id", supplierId, userId));
                CacheUtility.GetInstance().Add(string.Format("{0}_{1}_{2}_{3}", source, "base_shoppingcart_Id", supplierId, userId), shoppingCartIdDictionary.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));

                return new CacheServicesResult<BindShoppingCartResult>
                {
                    Result = new BindShoppingCartResult
                        {
                            ShoppingCartId = tempShoppingCartId,
                            IsNew = true
                        },
                    StatusCode = (int)StatusCode.Validate.NotFondShoppingCartCode
                };
            }

            var result = CacheUtility.GetInstance().Get(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", shoppingCartId)) as string;
            if (result.IsEmptyOrNull())
            {
                var tempShoppingCartId = this.GetShoppingCartId(source);
                shoppingCartIdDictionary.Add(tempShoppingCartId, true);
                CacheUtility.GetInstance().Delete(string.Format("{0}_{1}_{2}_{3}", source, "base_shoppingcart_Id", supplierId, userId));
                CacheUtility.GetInstance().Add(string.Format("{0}_{1}_{2}_{3}", source, "base_shoppingcart_Id", supplierId, userId), shoppingCartIdDictionary.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));

                return new CacheServicesResult<BindShoppingCartResult>
                {
                    Result = new BindShoppingCartResult
                    {
                        ShoppingCartId = tempShoppingCartId,
                        IsNew = true
                    },
                    StatusCode = (int)StatusCode.Validate.NotFondShoppingCartCode
                };
            }

            var shoppingCartBase = result.Deserialize<ShoppingCartBase>();
            if (shoppingCartBase != null && !shoppingCartBase.IsComplete)
            {
                foreach (var item in shoppingCartIdDictionary.Where(p => p.Key != shoppingCartId).Select(p => p.Key))
                {
                    var itemResult = CacheUtility.GetInstance().Get(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", item)) as string;
                    if (result.IsEmptyOrNull())
                    {
                        continue;
                    }

                    var itemShoppingCartBase = itemResult.Deserialize<ShoppingCartBase>();
                    if (itemShoppingCartBase.IsComplete)
                    {
                        continue;
                    }

                    itemShoppingCartBase.IsComplete = true;
                    CacheUtility.GetInstance().Delete(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", item));
                    CacheUtility.GetInstance().Add(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", item), itemShoppingCartBase.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
                }

                shoppingCartIdDictionary[lastShoppingCartId] = false;
                shoppingCartIdDictionary[shoppingCartId] = true;
                CacheUtility.GetInstance().Delete(string.Format("{0}_{1}_{2}_{3}", source, "base_shoppingcart_Id", supplierId, userId));
                CacheUtility.GetInstance().Add(string.Format("{0}_{1}_{2}_{3}", source, "base_shoppingcart_Id", supplierId, userId), shoppingCartIdDictionary.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
                return new CacheServicesResult<BindShoppingCartResult>
                    {
                        Result = new BindShoppingCartResult
                         {
                             ShoppingCartId = shoppingCartBase.ShoppingCartId
                         }
                    };
            }

            var newShoppingCartId = this.GetShoppingCartId(source);
            shoppingCartIdDictionary.Add(newShoppingCartId, true);
            shoppingCartIdDictionary[shoppingCartId] = false;
            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}_{2}_{3}", source, "base_shoppingcart_Id", supplierId, userId));
            CacheUtility.GetInstance().Add(string.Format("{0}_{1}_{2}_{3}", source, "base_shoppingcart_Id", supplierId, userId), shoppingCartIdDictionary.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));

            return new CacheServicesResult<BindShoppingCartResult>
            {
                Result = new BindShoppingCartResult
                {
                    ShoppingCartId = newShoppingCartId,
                    IsNew = true
                },
                StatusCode = (int)StatusCode.Validate.NotFondShoppingCartCode
            };
        }

        /// <summary>
        /// 获取购物车编号
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>
        /// 返回购物车编号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/2/2014 3:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private string GetShoppingCartId(string source)
        {
            var shoppingCartId = Guid.NewGuid().ToString();
            var newShoppingCartBase = new ShoppingCartBase
            {
                ShoppingCartId = shoppingCartId
            };

            CacheUtility.GetInstance().Add(string.Format("{0}_{1}_{2}", source, "base_shoppingcart_Id", shoppingCartId), newShoppingCartBase.Serialize(), DateTime.Now.AddDays(CacheServicesCommon.ShoppingCartCacheTime));
            return shoppingCartId;
        }
    }
}
