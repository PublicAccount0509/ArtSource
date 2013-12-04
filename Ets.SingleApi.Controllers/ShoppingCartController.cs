namespace Ets.SingleApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ShoppingCartController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 11:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartController : SingleApiController
    {
        /// <summary>
        /// 字段shoppingCartServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartServices shoppingCartServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartController"/> class.
        /// </summary>
        /// <param name="shoppingCartServices">The shoppingCartServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartController(IShoppingCartServices shoppingCartServices)
        {
            this.shoppingCartServices = shoppingCartServices;
        }

        /// <summary>
        /// 创建一个购物车
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
            var getShoppingCartResult = this.shoppingCartServices.GetShoppingCart(this.Source, id);
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

            var getShoppingCartResult = this.shoppingCartServices.SaveShoppingCart(this.Source, id, shoppingCartModel);
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

            var result = this.shoppingCartServices.GetShoppingCart(this.Source, id);
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> Create(int supplierId, string userId)
        {
            var createShoppingCartResult = this.shoppingCartServices.CreateShoppingCart(this.Source, supplierId, userId);
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

            var result = this.shoppingCartServices.GetShoppingCart(this.Source, createShoppingCartResult.Result);
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
            var saveShoppingCartCustomerResult = this.shoppingCartServices.SaveShoppingCartCustomer(this.Source, id, userId);
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

            var result = this.shoppingCartServices.GetShoppingCart(this.Source, id);
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
        /// 保存顾客信息
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

            var saveShoppingCartCustomerResult = this.shoppingCartServices.SaveShoppingCartDelivery(this.Source, id, delivery);
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

            var result = this.shoppingCartServices.GetShoppingCart(this.Source, id);
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> Shopping(string id, ShoppingCartShoppingRequst requst)
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
            var saveShoppingItemResult = this.shoppingCartServices.SaveShoppingItem(this.Source, id, shoppingCartItemList);
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

            var result = this.shoppingCartServices.GetShoppingCart(this.Source, id);
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> AddShopping(string id, ShoppingCartShoppingRequst requst)
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

            var saveShoppingItemResult = this.shoppingCartServices.AddShoppingItem(this.Source, id, requst.ShoppingCartItemList);
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

            var result = this.shoppingCartServices.GetShoppingCart(this.Source, id);
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> DeleteShopping(string id, ShoppingCartShoppingRequst requst)
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

            var saveShoppingItemResult = this.shoppingCartServices.DeleteShoppingItem(this.Source, id, requst.ShoppingCartItemList);
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

            var result = this.shoppingCartServices.GetShoppingCart(this.Source, id);
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<ShoppingCartModel> Order(string id, ShoppingCartOrderRequst requst)
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

            var saveShoppingItemResult = this.shoppingCartServices.SaveShoppingCartOrder(this.Source, id, order);
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

            var result = this.shoppingCartServices.GetShoppingCart(this.Source, id);
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
        /// <param name="deliveryMethodId">取餐方式</param>
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
            var saveShoppingCartOrderDeliveryMethodResult = this.shoppingCartServices.SaveShoppingCartOrderDeliveryMethod(this.Source, id, deliveryMethodId);
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

            var result = this.shoppingCartServices.GetShoppingCart(this.Source, id);
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