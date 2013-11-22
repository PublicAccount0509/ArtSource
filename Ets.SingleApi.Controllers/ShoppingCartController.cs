namespace Ets.SingleApi.Controllers
{
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
        public ShoppingCartResponse ShoppingCart(string id)
        {
            var getShoppingCartResult = this.shoppingCartServices.GetShoppingCart(id);
            if (getShoppingCartResult.Result == null)
            {
                return new ShoppingCartResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getShoppingCartResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            return new ShoppingCartResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = getShoppingCartResult.StatusCode
                },
                Result = getShoppingCartResult.Result
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
        public ShoppingCartResponse Create(int supplierId, int? userId)
        {
            var createShoppingCartResult = this.shoppingCartServices.CreateShoppingCart(supplierId, userId);
            if (createShoppingCartResult.Result == null)
            {
                return new ShoppingCartResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = createShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : createShoppingCartResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            return new ShoppingCartResponse
                {
                    Message = new ApiMessage
                        {
                            StatusCode = createShoppingCartResult.StatusCode
                        },
                    Result = createShoppingCartResult.Result
                };
        }

        /// <summary>
        /// 保存顾客信息
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
        public ShoppingCartResponse Customer(string id, int userId)
        {
            var saveShoppingCartCustomerResult = this.shoppingCartServices.SaveShoppingCartCustomer(id, userId);
            if (saveShoppingCartCustomerResult.Result == null)
            {
                return new ShoppingCartResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingCartCustomerResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : saveShoppingCartCustomerResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            return new ShoppingCartResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = saveShoppingCartCustomerResult.StatusCode
                },
                Result = saveShoppingCartCustomerResult.Result
            };
        }

        /// <summary>
        /// 保存商品信息
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
        public ShoppingCartResponse Shopping(string id, ShoppingCartShoppingRequst requst)
        {
            if (requst == null || requst.ShoppingCartItemList == null || requst.ShoppingCartItemList.Count == 0)
            {
                return new ShoppingCartResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var saveShoppingItemResult = this.shoppingCartServices.SaveShoppingItem(id, requst.ShoppingCartItemList);
            if (saveShoppingItemResult.Result == null)
            {
                return new ShoppingCartResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : saveShoppingItemResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            return new ShoppingCartResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = saveShoppingItemResult.StatusCode
                },
                Result = saveShoppingItemResult.Result
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
        public ShoppingCartResponse Order(string id, ShoppingCartOrderRequst requst)
        {
            if (requst == null)
            {
                return new ShoppingCartResponse
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
                    IsTakeInvoice = requst.IsTakeInvoice,
                    PaymentMethodId = requst.PaymentMethodId,
                    Template = requst.Template,
                    Path = requst.Path,
                    OrderNotes = requst.OrderNotes
                };

            var saveShoppingItemResult = this.shoppingCartServices.SaveShoppingCartOrder(id, order);
            if (saveShoppingItemResult.Result == null)
            {
                return new ShoppingCartResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = saveShoppingItemResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : saveShoppingItemResult.StatusCode
                    },
                    Result = new ShoppingCartModel()
                };
            }

            return new ShoppingCartResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = saveShoppingItemResult.StatusCode
                },
                Result = saveShoppingItemResult.Result
            };
        }
    }
}