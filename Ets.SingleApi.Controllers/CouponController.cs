namespace Ets.SingleApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：CouponController
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 类功能：优惠控制器
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 12:01 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CouponController : SingleApiController
    {
        /// <summary>
        /// 字段couponServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/9/2013 12:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ICouponServices couponServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponController"/> class.
        /// </summary>
        /// <param name="couponServices">The couponServices</param>
        /// 创建者：周超
        /// 创建日期：12/9/2013 12:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CouponController(ICouponServices couponServices)
        {
            this.couponServices = couponServices;
        }

        /// <summary>
        /// 取得优惠列表
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public ListResponse<SupplierCoupon> SupplierCouponList(SupplierCouponRequst requst)
        {
            if (requst == null)
            {
                return new ListResponse<SupplierCoupon>
                {
                    Result = new List<SupplierCoupon>(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var getSupplierCouponListResult = this.couponServices.GetSupplierCouponList(this.Source, new SupplierCouponParameter
            {
                Total = requst.Total,
                SupplierId = requst.SupplierId,
                UserId = requst.UserId,
                DeliveryMethodId = requst.DeliveryMethodId,
                DeliveryDate = requst.DeliveryDate ?? DateTime.Now
            });

            if (getSupplierCouponListResult.Result == null)
            {
                return new ListResponse<SupplierCoupon>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getSupplierCouponListResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getSupplierCouponListResult.StatusCode
                    },
                    Result = new List<SupplierCoupon>()
                };
            }


            var result = getSupplierCouponListResult.Result.Select(p => new SupplierCoupon
                {
                    SupplierCouponId = p.SupplierCouponId,
                    CouponTypeId = p.CouponTypeId,
                    Description = p.Description,
                    Discount = p.Discount
                }).ToList();

            return new ListResponse<SupplierCoupon>
            {
                Message = new ApiMessage
                {
                    StatusCode = getSupplierCouponListResult.StatusCode
                },
                Result = result,
                Cache = new ApiCache
                {
                    ExpiresIn = CommonUtility.GetTokenExpiresIn()
                }
            };
        }

        /// <summary>
        /// 取得优惠信息
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<decimal> SupplierCoupon(SupplierCouponRequst requst)
        {
            if (requst == null)
            {
                return new Response<decimal>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var getSupplierCouponResult = this.couponServices.GetSupplierCoupon(this.Source, new SupplierCouponParameter
            {
                Total = requst.Total,
                SupplierId = requst.SupplierId,
                UserId = requst.UserId,
                DeliveryMethodId = requst.DeliveryMethodId,
                DeliveryDate = requst.DeliveryDate ?? DateTime.Now
            });

            return new Response<decimal>
            {
                Message = new ApiMessage
                {
                    StatusCode = getSupplierCouponResult.StatusCode
                },
                Result = getSupplierCouponResult.Result
            };
        }
    }
}