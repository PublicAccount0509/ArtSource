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
    /// 类名称：HuangTaiJiShoppingCartController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：黄太极购物车功能
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/25/2013 11:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiShoppingCartController : SingleApiController
    {
        /// <summary>
        /// 字段huangTaiJiShoppingCartServices
        /// </summary>
        /// 创建者：殷超
        /// 创建日期：2013/12/27 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IHuangTaiJiShoppingCartServices huangTaiJiShoppingCartServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="HuangTaiJiShoppingCartController"/> class.
        /// </summary>
        /// <param name="huangTaiJiShoppingCartServices">The huangTaiJiShoppingCartServices</param>
        /// 创建者：殷超
        /// 创建日期：2013/12/27 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiShoppingCartController(IHuangTaiJiShoppingCartServices huangTaiJiShoppingCartServices)
        {
            this.huangTaiJiShoppingCartServices = huangTaiJiShoppingCartServices;
        }

        /// <summary>
        /// 根据购物车Id获取购物车信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<HuangTaiJiShoppingCartModel> ShoppingCart(string id)
        {
            var getShoppingCartResult = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, id);
            if (getShoppingCartResult.Result == null)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getShoppingCartResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            return new Response<HuangTaiJiShoppingCartModel>
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
        /// 创建者：殷超
        /// 创建日期：12/25/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HuangTaiJiShoppingCartModel> ShoppingCart(string id, HuangTaiJiShoppingCartRequst requst)
        {
            if (requst == null)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var shoppingCartModel = new HuangTaiJiShoppingCartModel
            {
                Delivery = requst.Delivery,
                Order = requst.Order,
                ShoppingCart = requst.ShoppingCart
            };

            var getShoppingCartResult = this.huangTaiJiShoppingCartServices.SaveShoppingCart(this.Source, id, shoppingCartModel);
            if (!getShoppingCartResult.Result)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getShoppingCartResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var result = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HuangTaiJiShoppingCartModel>
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
        /// 创建者：殷超
        /// 创建日期：12/25/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HuangTaiJiShoppingCartModel> Create(int supplierId, string userId)
        {
            var createShoppingCartResult = this.huangTaiJiShoppingCartServices.CreateShoppingCart(this.Source, supplierId, userId);
            if (createShoppingCartResult.Result.IsEmptyOrNull())
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = createShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : createShoppingCartResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var result = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, createShoppingCartResult.Result);
            return new Response<HuangTaiJiShoppingCartModel>
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
        /// 创建者：殷超
        /// 创建日期：12/25/2013 9:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HuangTaiJiShoppingCartModel> Customer(string id, int userId)
        {
            var saveShoppingCartCustomerResult = this.huangTaiJiShoppingCartServices.SaveShoppingCartCustomer(this.Source, id, userId);
            if (!saveShoppingCartCustomerResult.Result)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var result = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HuangTaiJiShoppingCartModel>
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
        /// 创建者：殷超
        /// 创建日期：12/25/2013 9:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HuangTaiJiShoppingCartModel> Delivery(string id, ShoppingCartDeliveryRequst requst)
        {
            if (requst == null)
            {
                return new Response<HuangTaiJiShoppingCartModel>
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

            var saveShoppingCartCustomerResult = this.huangTaiJiShoppingCartServices.SaveShoppingCartDelivery(this.Source, id, delivery);
            if (!saveShoppingCartCustomerResult.Result)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var result = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HuangTaiJiShoppingCartModel>
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
        /// 创建者：殷超
        /// 创建日期：12/25/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HuangTaiJiShoppingCartModel> Shopping(string id, HuangTaiJiShoppingCartShoppingRequst requst, bool saveDeliveryMethodId = true)
        {
            if (requst == null)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var shoppingCartItemList = requst.ShoppingCartItemList ?? new List<HuangTaiJiShoppingCartItem>();
            var saveShoppingItemResult = this.huangTaiJiShoppingCartServices.SaveShoppingItem(this.Source, id, shoppingCartItemList, saveDeliveryMethodId);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var result = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HuangTaiJiShoppingCartModel>
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
        /// 创建者：殷超
        /// 创建日期：12/25/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HuangTaiJiShoppingCartModel> AddShopping(string id, HuangTaiJiShoppingCartShoppingRequst requst, bool saveDeliveryMethodId = true)
        {
            if (requst == null || requst.ShoppingCartItemList == null || requst.ShoppingCartItemList.Count == 0)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var saveShoppingItemResult = this.huangTaiJiShoppingCartServices.AddShoppingItem(this.Source, id, requst.ShoppingCartItemList, saveDeliveryMethodId);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var result = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HuangTaiJiShoppingCartModel>
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
        /// 创建者：殷超
        /// 创建日期：12/25/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HuangTaiJiShoppingCartModel> DeleteShopping(string id, HuangTaiJiShoppingCartShoppingRequst requst, bool saveDeliveryMethodId = true)
        {
            if (requst == null || requst.ShoppingCartItemList == null || requst.ShoppingCartItemList.Count == 0)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var saveShoppingItemResult = this.huangTaiJiShoppingCartServices.DeleteShoppingItem(this.Source, id, requst.ShoppingCartItemList, saveDeliveryMethodId);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var result = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HuangTaiJiShoppingCartModel>
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
        /// 创建者：殷超
        /// 创建日期：12/25/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HuangTaiJiShoppingCartModel> Order(string id, ShoppingCartOrderRequst requst, bool isCalculateCoupon = false)
        {
            if (requst == null)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var order = new HuangTaiJiShoppingCartOrder
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

            var saveShoppingItemResult = this.huangTaiJiShoppingCartServices.SaveShoppingCartOrder(this.Source, id, order, isCalculateCoupon);
            if (!saveShoppingItemResult.Result)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var result = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HuangTaiJiShoppingCartModel>
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
        /// 创建者：殷超
        /// 创建日期：12/25/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HuangTaiJiShoppingCartModel> SaveDeliveryMethod(string id, int deliveryMethodId)
        {
            var saveShoppingCartOrderDeliveryMethodResult = this.huangTaiJiShoppingCartServices.SaveShoppingCartOrderDeliveryMethod(this.Source, id, deliveryMethodId);
            if (!saveShoppingCartOrderDeliveryMethodResult.Result)
            {
                return new Response<HuangTaiJiShoppingCartModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartOrderDeliveryMethodResult.StatusCode
                    },
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var result = this.huangTaiJiShoppingCartServices.GetShoppingCart(this.Source, id);
            return new Response<HuangTaiJiShoppingCartModel>
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