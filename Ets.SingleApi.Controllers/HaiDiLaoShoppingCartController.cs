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
    /// 类名称：HaiDiLaoShoppingCartController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 11:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HaiDiLaoShoppingCartController : SingleApiController
    {
        /// <summary>
        /// 字段haiDiLaoshoppingCartServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IHaiDiLaoShoppingCartServices haiDiLaoshoppingCartServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartController"/> class.
        /// </summary>
        /// <param name="haiDiLaoshoppingCartServices">The haiDiLaoshoppingCartServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HaiDiLaoShoppingCartController(IHaiDiLaoShoppingCartServices haiDiLaoshoppingCartServices)
        {
            this.haiDiLaoshoppingCartServices = haiDiLaoshoppingCartServices;
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
        public Response<HaiDiLaoShoppingCartModel> ShoppingCart(string id)
        {
            var getShoppingCartResult = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            if (getShoppingCartResult.Result == null)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getShoppingCartResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            return new Response<HaiDiLaoShoppingCartModel>
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
        public Response<HaiDiLaoShoppingCartModel> ShoppingCart(string id, HaiDiLaoShoppingCartRequst requst)
        {
            if (requst == null)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var haiDiLaoShoppingCartModel = new HaiDiLaoShoppingCartModel
                {
                    Delivery = requst.Delivery,
                    Order = requst.Order,
                    ShoppingCart = requst.ShoppingCart
                };

            var getShoppingCartResult = this.haiDiLaoshoppingCartServices.SaveShoppingCart(this.Source, id, haiDiLaoShoppingCartModel);
            if (!getShoppingCartResult.Result)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getShoppingCartResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HaiDiLaoShoppingCartModel>
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HaiDiLaoShoppingCartModel> Create(int supplierId, string userId)
        {
            var createShoppingCartResult = this.haiDiLaoshoppingCartServices.CreateShoppingCart(this.Source, supplierId, userId);
            if (createShoppingCartResult.Result.IsEmptyOrNull())
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = createShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : createShoppingCartResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, createShoppingCartResult.Result);
            return new Response<HaiDiLaoShoppingCartModel>
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
        public Response<HaiDiLaoShoppingCartModel> Customer(string id, int userId)
        {
            var saveShoppingCartCustomerResult = this.haiDiLaoshoppingCartServices.SaveShoppingCartCustomer(this.Source, id, userId);
            if (!saveShoppingCartCustomerResult.Result)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HaiDiLaoShoppingCartModel>
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
        public Response<HaiDiLaoShoppingCartModel> Delivery(string id, HaiDiLaoShoppingCartDeliveryRequst requst)
        {
            if (requst == null)
            {
                return new Response<HaiDiLaoShoppingCartModel>
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

            var saveShoppingCartCustomerResult = this.haiDiLaoshoppingCartServices.SaveShoppingCartDelivery(this.Source, id, delivery);
            if (!saveShoppingCartCustomerResult.Result)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HaiDiLaoShoppingCartModel>
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
        public Response<HaiDiLaoShoppingCartModel> Extra(string id, HaiDiLaoShoppingCartExtraRequst requst)
        {
            if (requst == null)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var extra = new ShoppingCartExtra
                {
                    CookingCount = requst.CookingCount,
                    PanCount = requst.PanCount,
                    DiningCount = requst.DiningCount
                };

            var saveShoppingCartCustomerResult = this.haiDiLaoshoppingCartServices.SaveShoppingCartExtra(this.Source, id, extra);
            if (!saveShoppingCartCustomerResult.Result)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HaiDiLaoShoppingCartModel>
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
        public Response<HaiDiLaoShoppingCartModel> Shopping(string id, HaiDiLaoShoppingCartShoppingRequst requst, bool saveDeliveryMethodId = true)
        {
            if (requst == null)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var shoppingCartItemList = requst.ShoppingCartItemList ?? new List<ShoppingCartItem>();
            var saveShoppingItemResult = this.haiDiLaoshoppingCartServices.SaveShoppingItem(this.Source, id, shoppingCartItemList, saveDeliveryMethodId);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HaiDiLaoShoppingCartModel>
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
        public Response<HaiDiLaoShoppingCartModel> AddShopping(string id, HaiDiLaoShoppingCartShoppingRequst requst, bool saveDeliveryMethodId = true)
        {
            if (requst == null || requst.ShoppingCartItemList == null || requst.ShoppingCartItemList.Count == 0)
            {
                return new Response<HaiDiLaoShoppingCartModel>
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

            var saveShoppingItemResult = this.haiDiLaoshoppingCartServices.AddShoppingItem(this.Source, id, shoppingCartItemList, saveDeliveryMethodId);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HaiDiLaoShoppingCartModel>
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
        public Response<HaiDiLaoShoppingCartModel> DeleteShopping(string id, HaiDiLaoShoppingCartShoppingRequst requst, bool saveDeliveryMethodId = true)
        {
            if (requst == null || requst.ShoppingCartItemList == null || requst.ShoppingCartItemList.Count == 0)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var saveShoppingItemResult = this.haiDiLaoshoppingCartServices.DeleteShoppingItem(this.Source, id, requst.ShoppingCartItemList, saveDeliveryMethodId);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HaiDiLaoShoppingCartModel>
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
        public Response<HaiDiLaoShoppingCartModel> Order(string id, HaiDiLaoShoppingCartOrderRequst requst, bool isCalculateCoupon = false, bool isValidateDeliveryTime = true)
        {
            if (requst == null)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var order = new HaiDiLaoShoppingCartOrder
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

            var saveShoppingItemResult = this.haiDiLaoshoppingCartServices.SaveShoppingCartOrder(this.Source, id, order, isCalculateCoupon, isValidateDeliveryTime);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HaiDiLaoShoppingCartModel>
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
        public Response<HaiDiLaoShoppingCartModel> SaveDeliveryMethod(string id, int deliveryMethodId)
        {
            var saveShoppingCartOrderDeliveryMethodResult = this.haiDiLaoshoppingCartServices.SaveShoppingCartOrderDeliveryMethod(this.Source, id, deliveryMethodId);
            if (!saveShoppingCartOrderDeliveryMethodResult.Result)
            {
                return new Response<HaiDiLaoShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartOrderDeliveryMethodResult.StatusCode
                    },
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var result = this.haiDiLaoshoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HaiDiLaoShoppingCartModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 激活购物车
        /// </summary>
        /// <param name="id">订单Id</param>
        /// <returns>
        /// 返回是否激活成功
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 11:16 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> ActivationShoppingCart(int id)
        {
            if (!this.ValidateUserId(id))
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            var result = this.haiDiLaoshoppingCartServices.ActivationShoppingCart(this.Source, id);
            return new Response<bool>
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