namespace Ets.SingleApi.Controllers
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
    /// 类名称：EtsWapShoppingCartController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 11:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapShoppingCartController : SingleApiController
    {
        /// <summary>
        /// 字段etsWapShoppingCartServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IEtsWapShoppingCartServices etsWapShoppingCartServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="EtsWapShoppingCartController"/> class.
        /// </summary>
        /// <param name="etsWapShoppingCartServices">The etsWapShoppingCartServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapShoppingCartController(IEtsWapShoppingCartServices etsWapShoppingCartServices)
        {
            this.etsWapShoppingCartServices = etsWapShoppingCartServices;
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
                return base.PreFix + OrderType.WaiMai.ToString();
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
        public Response<ShoppingCartModel> ShoppingCart(string id)
        {
            var getShoppingCartResult = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, id);
            if (getShoppingCartResult.Result == null)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getShoppingCartResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            return new Response<ShoppingCartModel>
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
        public Response<ShoppingCartModel> ShoppingCart(string id, ShoppingCartRequst requst)
        {
            if (requst == null)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var shoppingCartModel = new ShoppingCartModel
                {
                    Delivery = requst.Delivery,
                    Order = requst.Order,
                    ShoppingCart = requst.ShoppingCart
                };

            var getShoppingCartResult = this.etsWapShoppingCartServices.SaveShoppingCart(this.Source, id, shoppingCartModel);
            if (!getShoppingCartResult.Result)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getShoppingCartResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            var result = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<ShoppingCartModel>
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
        public Response<ShoppingCartModel> Create(int supplierId, string userId, int orderId = 0)
        {
            var createShoppingCartResult = this.etsWapShoppingCartServices.CreateShoppingCart(this.Source, supplierId, userId, orderId);
            if (createShoppingCartResult.Result.IsEmptyOrNull())
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = createShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : createShoppingCartResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            var result = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, createShoppingCartResult.Result);
            return new Response<ShoppingCartModel>
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
        public Response<ShoppingCartModel> Customer(string id, int userId)
        {
            var saveShoppingCartCustomerResult = this.etsWapShoppingCartServices.SaveShoppingCartCustomer(this.Source, id, userId);
            if (!saveShoppingCartCustomerResult.Result)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            var result = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<ShoppingCartModel>
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
        public Response<ShoppingCartModel> Delivery(string id, ShoppingCartDeliveryRequst requst)
        {
            if (requst == null)
            {
                return new Response<ShoppingCartModel>
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

            var saveShoppingCartCustomerResult = this.etsWapShoppingCartServices.SaveShoppingCartDelivery(this.Source, id, delivery);
            if (!saveShoppingCartCustomerResult.Result)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            var result = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<ShoppingCartModel>
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
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> Shopping(string id, ShoppingCartShoppingRequst requst, bool saveDeliveryMethodId = true)
        {
            if (requst == null)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var shoppingCartItemList = requst.ShoppingCartItemList ?? new List<ShoppingCartItem>();
            var saveShoppingItemResult = this.etsWapShoppingCartServices.SaveShoppingItem(this.Source, id, shoppingCartItemList, saveDeliveryMethodId);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            var result = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<ShoppingCartModel>
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
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> AddShopping(string id, ShoppingCartShoppingRequst requst, bool saveDeliveryMethodId = true)
        {
            if (requst == null || requst.ShoppingCartItemList == null || requst.ShoppingCartItemList.Count == 0)
            {
                return new Response<ShoppingCartModel>
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

            var saveShoppingItemResult = this.etsWapShoppingCartServices.AddShoppingItem(this.Source, id, shoppingCartItemList, saveDeliveryMethodId);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            var result = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<ShoppingCartModel>
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
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> DeleteShopping(string id, ShoppingCartShoppingRequst requst, bool saveDeliveryMethodId = true)
        {
            if (requst == null || requst.ShoppingCartItemList == null || requst.ShoppingCartItemList.Count == 0)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var saveShoppingItemResult = this.etsWapShoppingCartServices.DeleteShoppingItem(this.Source, id, requst.ShoppingCartItemList, saveDeliveryMethodId);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            var result = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<ShoppingCartModel>
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
        /// <param name="isValidateDeliveryTime">是否检测送餐时间</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> Order(string id, ShoppingCartOrderRequst requst, bool isCalculateCoupon = false, bool isValidateDeliveryTime = true)
        {
            if (requst == null)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var order = new ShoppingCartOrder
                {
                    Id = requst.Id,
                    AreaId = requst.AreaId,
                    DeliveryDate = requst.DeliveryDate,
                    DeliveryInstruction = requst.DeliveryInstruction,
                    DeliveryMethodId = requst.DeliveryMethodId,
                    DeliveryTime = requst.DeliveryTime,
                    DeliveryType = requst.DeliveryType,
                    InvoiceRequired = requst.InvoiceRequired,
                    InvoiceTitle = requst.InvoiceTitle,
                    InvoiceType = requst.InvoiceType,
                    IsTakeInvoice = requst.IsTakeInvoice,
                    PaymentMethodId = requst.PaymentMethodId,
                    Template = requst.Template,
                    Path = requst.Path,
                    OrderNotes = requst.OrderNotes
                };

            var saveShoppingItemResult = this.etsWapShoppingCartServices.SaveShoppingCartOrder(this.Source, id, order, isCalculateCoupon, isValidateDeliveryTime);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            var result = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<ShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 保存送餐方式
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="deliveryMethodId">送餐方式Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> SaveDeliveryMethod(string id, int deliveryMethodId)
        {
            var saveShoppingCartOrderDeliveryMethodResult = this.etsWapShoppingCartServices.SaveShoppingCartOrderDeliveryMethod(this.Source, id, deliveryMethodId);
            if (!saveShoppingCartOrderDeliveryMethodResult.Result)
            {
                return new Response<ShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartOrderDeliveryMethodResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            var result = this.etsWapShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<ShoppingCartModel>
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