﻿namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：CouponServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：优惠信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 11:29 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CouponServices : ICouponServices
    {
        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/9/2013 11:29 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/9/2013 11:29 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段supplierCouponProviderList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/9/2013 11:29 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<ISupplierCouponProvider> supplierCouponProviderList;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="supplierCouponProviderList">The supplierCouponProviderList</param>
        /// 创建者：周超
        /// 创建日期：12/9/2013 11:28 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CouponServices(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            List<ISupplierCouponProvider> supplierCouponProviderList)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.supplierCouponProviderList = supplierCouponProviderList;
        }

        /// <summary>
        /// 取得优惠列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierCouponModel> GetSupplierCouponList(string source, SupplierCouponParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<SupplierCouponModel>
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest,
                        Result = new List<SupplierCouponModel>()
                    };
            }

            if (parameter.Total <= 0)
            {
                return new ServicesResultList<SupplierCouponModel>
                    {
                        Result = new List<SupplierCouponModel>()
                    };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResultList<SupplierCouponModel>
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                        Result = new List<SupplierCouponModel>()
                    };
            }

            if (parameter.UserId != null && !this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResultList<SupplierCouponModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new List<SupplierCouponModel>()
                };
            }

            var supplierCouponProvider = this.supplierCouponProviderList.FirstOrDefault(p => p.DeliveryMethodType == (DeliveryMethodType)parameter.DeliveryMethodId);
            if (supplierCouponProvider == null)
            {
                return new ServicesResultList<SupplierCouponModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryMethodId,
                    Result = new List<SupplierCouponModel>()
                };
            }

            var supplierCouponList = supplierCouponProvider.CalculateCoupon(parameter.Total, parameter.SupplierId, parameter.DeliveryDate, parameter.UserId) ?? new List<SupplierCouponModel>();
            return new ServicesResultList<SupplierCouponModel>
            {
                StatusCode = supplierCouponList.Count == 0 ? (int)StatusCode.Succeed.Empty : (int)StatusCode.Succeed.Ok,
                Result = supplierCouponList
            };
        }

        /// <summary>
        /// 取得优惠信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<decimal> GetSupplierCoupon(string source, SupplierCouponParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (parameter.Total <= 0)
            {
                return new ServicesResult<decimal>();
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                };
            }

            if (parameter.UserId != null && !this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode
                };
            }

            var supplierCouponProvider = this.supplierCouponProviderList.FirstOrDefault(p => p.DeliveryMethodType == (DeliveryMethodType)parameter.DeliveryMethodId);
            if (supplierCouponProvider == null)
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryMethodId
                };
            }

            var supplierCouponList = supplierCouponProvider.CalculateCoupon(parameter.Total, parameter.SupplierId, parameter.DeliveryDate, parameter.UserId) ?? new List<SupplierCouponModel>();
            var result = ServicesCommon.CalculateCoupon(parameter.Total, ServicesCommon.CalculateCouponWay, supplierCouponList);
            return new ServicesResult<decimal>
                {
                    Result = result
                };
        }
    }
}