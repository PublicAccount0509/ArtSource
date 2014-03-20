﻿namespace Ets.SingleApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：EtsWapPaiDuiShoppingCartController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 11:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapPaiDuiShoppingCartController : SingleApiController
    {
        /// <summary>
        /// 字段etsWapPaiDuiShoppingCartServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IEtsWapPaiDuiShoppingCartServices etsWapPaiDuiShoppingCartServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="EtsWapPaiDuiShoppingCartController" /> class.
        /// </summary>
        /// <param name="etsWapPaiDuiShoppingCartServices">The ets wap tang shi shopping cart services.</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapPaiDuiShoppingCartController(IEtsWapPaiDuiShoppingCartServices etsWapPaiDuiShoppingCartServices)
        {
            this.etsWapPaiDuiShoppingCartServices = etsWapPaiDuiShoppingCartServices;
        }

        /// <summary>
        /// Gets or sets the PreFix of SingleApiController
        /// </summary>
        /// <value>
        /// The PreFix
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/14/2014 2:18 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected override string PreFix
        {
            get
            {
                return base.PreFix + OrderType.PaiDui.ToString();
            }
        }

        /// <summary>
        /// 根据购物车Id获取购物车信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<EtsWapPaiDuiShoppingCartModel> ShoppingCart(string id)
        {
            var getShoppingCartResult = this.etsWapPaiDuiShoppingCartServices.GetShoppingCart(this.Source, id);
            if (getShoppingCartResult.Result == null)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getShoppingCartResult.StatusCode
                    },
                    Result = new EtsWapPaiDuiShoppingCartModel()
                };
            }

            return new Response<EtsWapPaiDuiShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = getShoppingCartResult.StatusCode
                },
                Result = getShoppingCartResult.Result
            };
        }

        /// <summary>
        /// 保存一个购物车
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">购物车信息</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<EtsWapPaiDuiShoppingCartModel> ShoppingCart(string id, EtsWapPaiDuiShoppingCartRequst requst)
        {
            if (requst == null)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var shoppingCartModel = new EtsWapPaiDuiShoppingCartModel
                {
                    Delivery = requst.Delivery,
                    Order = requst.Order,
                    ShoppingCart = requst.ShoppingCart
                };

            var getShoppingCartResult = this.etsWapPaiDuiShoppingCartServices.SaveShoppingCart(this.Source, id, shoppingCartModel);
            if (!getShoppingCartResult.Result)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getShoppingCartResult.StatusCode
                    },
                    Result = new EtsWapPaiDuiShoppingCartModel()
                };
            }

            var result = this.etsWapPaiDuiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<EtsWapPaiDuiShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<EtsWapPaiDuiShoppingCartModel> Create(int supplierId, string userId, int orderId = 0)
        {
            var createShoppingCartResult = this.etsWapPaiDuiShoppingCartServices.CreateShoppingCart(this.Source, supplierId, userId, orderId);
            if (createShoppingCartResult.Result.IsEmptyOrNull())
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = createShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : createShoppingCartResult.StatusCode
                    },
                    Result = new EtsWapPaiDuiShoppingCartModel()
                };
            }

            var result = this.etsWapPaiDuiShoppingCartServices.GetShoppingCart(this.Source, createShoppingCartResult.Result);
            return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result
                };
        }

        /// <summary>
        /// 关联顾客信息
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="userId">The userId</param>
        /// <returns>
        /// The ShoppingCartResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<EtsWapPaiDuiShoppingCartModel> Customer(string id, int userId)
        {
            var saveShoppingCartCustomerResult = this.etsWapPaiDuiShoppingCartServices.SaveShoppingCartCustomer(this.Source, id, userId);
            if (!saveShoppingCartCustomerResult.Result)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new EtsWapPaiDuiShoppingCartModel()
                };
            }

            var result = this.etsWapPaiDuiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<EtsWapPaiDuiShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 保存送餐信息
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// The ShoppingCartResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<EtsWapPaiDuiShoppingCartModel> Delivery(string id, EtsWapPaiDuiShoppingCartDeliveryRequst requst)
        {
            if (requst == null)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var delivery = new ShoppingCartDelivery
                {
                    Name = requst.Name,
                    Telephone = requst.Telephone,
                    Gender = requst.Gender,
                    IpAddress = requst.IpAddress,
                    CustomerAddressId = requst.CustomerAddressId
                };

            var saveShoppingCartCustomerResult = this.etsWapPaiDuiShoppingCartServices.SaveShoppingCartDelivery(this.Source, id, delivery);
            if (!saveShoppingCartCustomerResult.Result)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new EtsWapPaiDuiShoppingCartModel()
                };
            }

            var result = this.etsWapPaiDuiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<EtsWapPaiDuiShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 保存全部商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">商品信息</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<EtsWapPaiDuiShoppingCartModel> Shopping(string id, EtsWapPaiDuiShoppingCartShoppingRequst requst)
        {
            if (requst == null)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var shoppingCartItemList = requst.ShoppingCartItemList ?? new List<ShoppingCartItem>();
            var saveShoppingItemResult = this.etsWapPaiDuiShoppingCartServices.SaveShoppingItem(this.Source, id, shoppingCartItemList);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new EtsWapPaiDuiShoppingCartModel()
                };
            }

            var result = this.etsWapPaiDuiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<EtsWapPaiDuiShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">商品信息</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<EtsWapPaiDuiShoppingCartModel> AddShopping(string id, ShoppingCartShoppingRequst requst)
        {
            if (requst == null || requst.ShoppingCartItemList == null || requst.ShoppingCartItemList.Count == 0)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var shoppingCartItemList = requst.ShoppingCartItemList;
            foreach (var shoppingCartItem in shoppingCartItemList.Where(shoppingCartItem => shoppingCartItem.CategoryIdList == null))
            {
                shoppingCartItem.CategoryIdList = new List<int>();
            }

            var saveShoppingItemResult = this.etsWapPaiDuiShoppingCartServices.AddShoppingItem(this.Source, id, shoppingCartItemList);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new EtsWapPaiDuiShoppingCartModel()
                };
            }

            var result = this.etsWapPaiDuiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<EtsWapPaiDuiShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">商品信息</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<EtsWapPaiDuiShoppingCartModel> DeleteShopping(string id, ShoppingCartShoppingRequst requst)
        {
            if (requst == null || requst.ShoppingCartItemList == null || requst.ShoppingCartItemList.Count == 0)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var saveShoppingItemResult = this.etsWapPaiDuiShoppingCartServices.DeleteShoppingItem(this.Source, id, requst.ShoppingCartItemList);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new EtsWapPaiDuiShoppingCartModel()
                };
            }

            var result = this.etsWapPaiDuiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<EtsWapPaiDuiShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">订单信息</param>
        /// <param name="isCalculateCoupon">是否计算优惠</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<EtsWapPaiDuiShoppingCartModel> Order(string id, EtsWapPaiDuiShoppingCartOrderRequst requst, bool isCalculateCoupon = false)
        {
            if (requst == null)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var order = new EtsWapPaiDuiShoppingCartOrder
                {
                    Id = requst.Id,
                    OrderInstruction = requst.OrderInstruction,
                    DinnerMethodId = requst.DinnerMethodId,
                    DinnerNumber = requst.DinnerNumber,
                    SeatNumber = requst.SeatNumber,
                    LineNumber = requst.LineNumber,
                    AreaId = requst.AreaId,
                    InvoiceRequired = requst.InvoiceRequired,
                    InvoiceTitle = requst.InvoiceTitle,
                    InvoiceType = requst.InvoiceType,
                    IsTakeInvoice = requst.IsTakeInvoice,
                    PaymentMethodId = requst.PaymentMethodId,
                    Template = requst.Template,
                    Path = requst.Path,
                    OrderNotes = requst.OrderNotes,
                    CouponCode = requst.CouponCode
                };

            var saveShoppingItemResult = this.etsWapPaiDuiShoppingCartServices.SaveShoppingCartOrder(this.Source, id, order, isCalculateCoupon);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<EtsWapPaiDuiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new EtsWapPaiDuiShoppingCartModel()
                };
            }

            var result = this.etsWapPaiDuiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<EtsWapPaiDuiShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }
    }
}