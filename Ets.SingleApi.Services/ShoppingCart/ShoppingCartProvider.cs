namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.ICacheServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ShoppingCartProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 2:41 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartProvider : IShoppingCartProvider
    {
        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 12:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

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
        /// Initializes a new instance of the <see cref="ShoppingCartProvider" /> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="shoppingCartCacheServices">The shoppingCartCacheServices</param>
        /// <param name="shoppingCartBusinessServiceList">The shoppingCartBusinessServiceList</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartProvider(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            IShoppingCartCacheServices shoppingCartCacheServices,
            List<IShoppingCartBusinessService> shoppingCartBusinessServiceList)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.shoppingCartCacheServices = shoppingCartCacheServices;
            this.shoppingCartBusinessServiceList = shoppingCartBusinessServiceList;
        }

        /// <summary>
        /// 获取购物车商家信息
        /// </summary>
        /// <param name="type">购物车类型</param>
        /// <param name="businessId">商家Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:07 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<IShoppingCartBusiness> GetShoppingCartBusiness(int type, int businessId)
        {
            var shoppingCartCacheResult = this.shoppingCartCacheServices.GetShoppingCartBusiness(type, businessId);
            if (shoppingCartCacheResult != null && shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<IShoppingCartBusiness>
                {
                    Result = shoppingCartCacheResult.Result
                };
            }

            var shoppingCartBusinessService = this.shoppingCartBusinessServiceList.FirstOrDefault(p => p.BusinessType == (BusinessType)type);
            if (shoppingCartBusinessService == null)
            {
                return null;
            }

            var getShoppingCartBusinessResult = shoppingCartBusinessService.GetShoppingCartBusiness(businessId);
            if (getShoppingCartBusinessResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                this.shoppingCartCacheServices.SaveShoppingCartBusiness(type, getShoppingCartBusinessResult.Result);
            }

            return new ServicesResult<IShoppingCartBusiness>
            {
                StatusCode = getShoppingCartBusinessResult.StatusCode,
                Result = getShoppingCartBusinessResult.Result
            };
        }

        /// <summary>
        /// 获取购物车顾客信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartCustomer> GetShoppingCartCustomer(int userId)
        {
            var shoppingCartCacheResult = this.shoppingCartCacheServices.GetShoppingCartCustomer(userId);
            if (shoppingCartCacheResult != null && shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartCustomer>
                {
                    Result = shoppingCartCacheResult.Result
                };
            }

            var tempCustomer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == userId)
                  .Select(p => new
                  {
                      UserId = p.LoginId,
                      Telephone = p.Mobile,
                      p.Email,
                      p.Gender,
                      p.Forename,
                      p.Surname
                  }).FirstOrDefault();

            if (tempCustomer == null)
            {
                return new ServicesResult<ShoppingCartCustomer>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ShoppingCartCustomer()
                };
            }

            var customer = new ShoppingCartCustomer
            {
                UserId = tempCustomer.UserId ?? 0,
                Telephone = tempCustomer.Telephone,
                Email = tempCustomer.Email,
                Gender = string.Equals(tempCustomer.Gender, ServicesCommon.FemaleGender, StringComparison.OrdinalIgnoreCase) ? "1" : "0",
                Name = string.Format("{0}{1}", tempCustomer.Forename, tempCustomer.Surname)
            };

            this.shoppingCartCacheServices.SaveShoppingCartCustomer(customer);
            return new ServicesResult<ShoppingCartCustomer>
            {
                Result = customer
            };
        }

        /// <summary>
        /// 获取购物车信息
        /// </summary>
        /// <param name="id">购物车唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCart> GetShoppingCart(string id)
        {
            var shoppingCartCacheResult = this.shoppingCartCacheServices.GetShoppingCart(id);
            if (shoppingCartCacheResult != null && shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCart>
                {
                    Result = shoppingCartCacheResult.Result
                };
            }

            var shoppingCart = new ShoppingCart
            {
                ShoppingCartId = id,
                IsActive = true
            };

            this.shoppingCartCacheServices.SaveShoppingCart(shoppingCart);
            return new ServicesResult<ShoppingCart>
            {
                Result = shoppingCart
            };
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="id">订单唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartOrder> GetShoppingCartOrder(string id)
        {
            var getShoppingCartOrderResult = this.shoppingCartCacheServices.GetShoppingCartOrder(id);
            return new ServicesResult<ShoppingCartOrder>
            {
                StatusCode = getShoppingCartOrderResult.StatusCode,
                Result = getShoppingCartOrderResult.Result ?? new ShoppingCartOrder()
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
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCart(ShoppingCart shoppingCart)
        {
            var saveShoppingCartResult = this.shoppingCartCacheServices.SaveShoppingCart(shoppingCart);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartResult.StatusCode,
                Result = saveShoppingCartResult.Result
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="shoppingCartOrder">订单信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrder(ShoppingCartOrder shoppingCartOrder)
        {
            var saveShoppingCartOrderResult = this.shoppingCartCacheServices.SaveShoppingCartOrder(shoppingCartOrder);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartOrderResult.StatusCode,
                Result = saveShoppingCartOrderResult.Result
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
        public ServicesResult<ShoppingCartLink> GetShoppingCartLink(string shoppingCartLinkId)
        {
            var getShoppingCartLinkResult = this.shoppingCartCacheServices.GetShoppingCartLink(shoppingCartLinkId);
            return new ServicesResult<ShoppingCartLink>
            {
                StatusCode = getShoppingCartLinkResult.StatusCode,
                Result = getShoppingCartLinkResult.Result ?? new ShoppingCartLink()
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
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartLink(ShoppingCartLink shoppingCartLink)
        {
            var saveShoppingCartLinkResult = this.shoppingCartCacheServices.SaveShoppingCartLink(shoppingCartLink);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartLinkResult.StatusCode,
                Result = saveShoppingCartLinkResult.Result
            };
        }
    }
}
