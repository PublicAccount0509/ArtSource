namespace Ets.SingleApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：UserController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：提供User相关的API
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 16:15
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UserController : ApiController
    {
        /// <summary>
        /// 字段usersServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:16
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IUsersServices usersServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="usersServices">The usersServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:16
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserController(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>
        /// The GetUserResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public GetUserResponse GetUser(int id)
        {
            var getUserResult = this.usersServices.GetUser(id);
            if (getUserResult.Result == null)
            {
                return new GetUserResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getUserResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getUserResult.StatusCode
                    },
                    Result = new Customer()
                };
            }

            var customerAddressList = getUserResult.Result.CustomerAddressList.Select(customerAddress => new CustomerAddress
                {
                    CustomerAddressId = customerAddress.CustomerAddressId,
                    Address = customerAddress.Address,
                    Name = customerAddress.Name,
                    Telephone = customerAddress.Telephone,
                    IsDefault = customerAddress.IsDefault,
                    CityId = customerAddress.CityId,
                    CountyId = customerAddress.CountyId,
                    ProvinceId = customerAddress.ProvinceId,
                    RegionCode = customerAddress.RegionCode,
                    Sex = customerAddress.Sex
                }).ToList();

            var result = new Customer
                {
                    UserId = getUserResult.Result.UserId,
                    UserName = getUserResult.Result.UserName,
                    Avatar = getUserResult.Result.Avatar,
                    Email = getUserResult.Result.Email,
                    Telephone = getUserResult.Result.Telephone,
                    CustomerAddressList = customerAddressList
                };

            return new GetUserResponse
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getUserResult.StatusCode
                        },
                    Result = result
                };
        }

        /// <summary>
        /// 保持用户地址
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="requst">地址信息</param>
        /// <returns>
        /// The CustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:41
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public CustomerAddressResponse CustomerAddress(int id, CustomerAddressRequst requst)
        {
            if (requst == null)
            {
                return new CustomerAddressResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var saveCustomerAddressResult = this.usersServices.SaveCustomerAddress(id, new CustomerAddressParameter
                {
                    CustomerAddressId = requst.CustomerAddressId,
                    Name = requst.Name,
                    Address = requst.Address,
                    AddressAlias = requst.AddressAlias,
                    IsDefault = requst.IsDefault,
                    RegionCode = requst.RegionCode,
                    Sex = requst.Sex,
                    Telephone = requst.Telephone
                });

            return new CustomerAddressResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = saveCustomerAddressResult.StatusCode
                }
            };
        }

        /// <summary>
        /// 删除用户地址
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="customerAddressIdList">用户地址Id</param>
        /// <returns>
        /// The DeleteCustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public DeleteCustomerAddressResponse DeleteCustomerAddress(int id, List<int> customerAddressIdList)
        {
            if (customerAddressIdList == null || customerAddressIdList.Count == 0)
            {
                return new DeleteCustomerAddressResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var deleteCustomerAddressResult = this.usersServices.DeleteCustomerAddress(id, customerAddressIdList);
            return new DeleteCustomerAddressResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = deleteCustomerAddressResult.StatusCode
                }
            };
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public RegisterUserResponse Register(RegisterUserRequst requst)
        {
            if (requst == null)
            {
                return new RegisterUserResponse
                {
                    Result = new RegisterUserResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var registerResult = this.usersServices.Register(new RegisterUserParameter
                {
                    Email = requst.Email,
                    Telephone = requst.Telephone,
                    Password = requst.Password,
                    AuthCode = requst.AuthCode
                });

            if (registerResult.Result == null)
            {
                return new RegisterUserResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = registerResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : registerResult.StatusCode
                    },
                    Result = new RegisterUserResult()
                };
            }

            var result = new RegisterUserResult
            {
                UserId = registerResult.Result.UserId,
                AccessToken = registerResult.Result.AccessToken,
                RefreshToken = registerResult.Result.RefreshToken,
                TokenType = registerResult.Result.TokenType
            };

            return new RegisterUserResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = registerResult.StatusCode
                },
                Result = result
            };
        }

        /// <summary>
        /// 获取用户收藏的餐厅列表
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>
        /// The FollowerSupplierListResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public FollowerSupplierListResponse FollowerSupplierList(int id)
        {
            var list = this.usersServices.GetFollowerSupplierList(id);

            if (list.Result == null || list.Result.Count == 0)
            {
                return new FollowerSupplierListResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<FollowerSupplier>()
                };
            }

            var result = list.Result.Select(p => new FollowerSupplier
                {
                    SupplierId = p.SupplierId,
                    SupplierName = p.SupplierName,
                    SupplierDescription = p.SupplierDescription,
                    Address = p.Address,
                    Averageprice = p.Averageprice,
                    AverageRating = p.AverageRating,
                    CuisineName = p.CuisineName,
                    LogoUrl = p.LogoUrl,
                    Telephone = p.Telephone
                }).ToList();

            return new FollowerSupplierListResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                Result = result
            };
        }

        /// <summary>
        /// 收藏餐厅
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="supplierIdList">餐厅Id列表</param>
        /// <returns>
        /// The AddFollowerSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public AddFollowerSupplierResponse AddFollowerSupplier(int id, List<int> supplierIdList)
        {
            if (supplierIdList == null || supplierIdList.Count == 0)
            {
                return new AddFollowerSupplierResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var addFollowerSupplierResult = this.usersServices.AddFollowerSupplier(id, supplierIdList);
            return new AddFollowerSupplierResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = addFollowerSupplierResult.StatusCode
                }
            };
        }

        /// <summary>
        /// 取消收藏餐厅
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="supplierIdList">餐厅Id列表</param>
        /// <returns>
        /// The DeleteFollowerSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public DeleteFollowerSupplierResponse DeleteFollowerSupplier(int id, List<int> supplierIdList)
        {
            if (supplierIdList == null || supplierIdList.Count == 0)
            {
                return new DeleteFollowerSupplierResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var addFollowerSupplierResult = this.usersServices.DeleteFollowerSupplier(id, supplierIdList);
            return new DeleteFollowerSupplierResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = addFollowerSupplierResult.StatusCode
                }
            };
        }

        /// <summary>
        /// 用户订单列表
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="orderType">订单类型</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="pageSize">每页最大数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// UserOrderListResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 14:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public UserOrderListResponse UserOrderList(int id, int orderType, int? orderStatus, int pageSize, int? pageIndex)
        {
            var list = this.usersServices.GetUserOrderList(id, orderStatus, (OrderType)orderType, pageSize, pageIndex);

            if (list.Result == null || list.Result.Count == 0)
            {
                return new UserOrderListResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<UserOrder>()
                };
            }

            var result = list.Result.Select(p => new UserOrder
            {
                OrderId = p.OrderId,
                SupplierId = p.SupplierId ?? 0,
                SupplierName = p.SupplierName,
                DateReserved = p.DateReserved == null ? string.Empty : p.DateReserved.Value.ToString("yyyy-MM-dd HH:mm"),
                CustomerTotal = p.CustomerTotal ?? 0,
                OrderStatusId = p.OrderStatusId ?? 0,
                OrderStatus = p.OrderStatus,
                OrderType = p.OrderType,
                DineNumber = p.DineNumber ?? 0
            }).ToList();

            return new UserOrderListResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                Result = result
            };
        }
    }
}