namespace Ets.SingleApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Linq;

    using Ets.SingleApi.Controllers.Filters;
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
    public class UserController : SingleApiController
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
        /// 是否存在
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// The ExistResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 5:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public ListResponse<ExistResult> Exist(ExistRequst requst)
        {
            if (requst == null || requst.ExistList == null || requst.ExistList.Count == 0)
            {
                return new ListResponse<ExistResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    },
                    Result = new List<ExistResult>()
                };
            }

            var existParameterList = requst.ExistList.Where(p => !p.Account.IsEmptyOrNull())
                                      .Select(p => new ExistParameter
                                          {
                                              Account = p.Account,
                                              Type = p.Type
                                          })
                                      .ToList();

            var existResult = this.usersServices.Exist(this.Source, existParameterList);
            if (existResult == null)
            {
                return new ListResponse<ExistResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.Succeed.Empty
                    },
                    Result = new List<ExistResult>()
                };
            }

            if (existResult.Result == null || existResult.Result.Count == 0)
            {
                return new ListResponse<ExistResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = existResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : existResult.StatusCode
                    },
                    Result = new List<ExistResult>()
                };
            }

            var result = existResult.Result.Select(
                            p => new ExistResult
                                {
                                    Account = p.Account ?? string.Empty,
                                    Exist = p.Exist,
                                    Login = p.Login
                                }).ToList();

            return new ListResponse<ExistResult>
            {
                Message = new ApiMessage
                {
                    StatusCode = existResult.StatusCode,
                },
                Result = result
            };
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
        [TokenFilter]
        public Response<Customer> GetUser(int id)
        {
            if (!this.ValidateUserId(id))
            {
                return new Response<Customer>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new Customer()
                };
            }

            var getUserResult = this.usersServices.GetUser(this.Source, id);
            if (getUserResult.Result == null)
            {
                return new Response<Customer>
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
                    Address = (customerAddress.Address ?? string.Empty),
                    Name = (customerAddress.Name ?? string.Empty),
                    Telephone = (customerAddress.Telephone ?? string.Empty),
                    IsDefault = customerAddress.IsDefault ?? false,
                    CityId = customerAddress.CityId,
                    CountyId = customerAddress.CountyId,
                    ProvinceId = customerAddress.ProvinceId,
                    RegionCode = (customerAddress.RegionCode ?? string.Empty),
                    Sex = customerAddress.Sex,
                    AddressBuilding = customerAddress.AddressBuilding ?? string.Empty,
                    AddressDetail = customerAddress.AddressDetail ?? string.Empty,
                    AddressAlias = customerAddress.AddressAlias ?? string.Empty
                }).ToList();

            var result = new Customer
                {
                    UserId = getUserResult.Result.UserId,
                    UserName = (getUserResult.Result.UserName ?? string.Empty),
                    Avatar = (getUserResult.Result.Avatar ?? string.Empty),
                    Email = (getUserResult.Result.Email ?? string.Empty),
                    Telephone = (getUserResult.Result.Telephone ?? string.Empty),
                    SupplierId = getUserResult.Result.SupplierId,
                    CustomerAddressList = customerAddressList
                };

            return new Response<Customer>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getUserResult.StatusCode
                        },
                    Result = result
                };
        }


        /// <summary>
        /// 获取用户信息(地址信息为订单地址帅选结果)
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
        [TokenFilter]
        public Response<Customer> GetUserWaiMaiAddress(int id)
        {
            if (!this.ValidateUserId(id))
            {
                return new Response<Customer>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int) StatusCode.OAuth.AccessDenied
                            },
                        Result = new Customer()
                    };
            }

            var getUserResult = this.usersServices.GetUserWaiMaiAddress(this.Source, id);
            if (getUserResult.Result == null)
            {
                return new Response<Customer>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    getUserResult.StatusCode == (int) StatusCode.Succeed.Ok
                                        ? (int) StatusCode.Succeed.Empty
                                        : getUserResult.StatusCode
                            },
                        Result = new Customer()
                    };
            }

            var customerAddressList =
                getUserResult.Result.CustomerAddressList.Select(customerAddress => new CustomerAddress
                    {
                        CustomerAddressId = customerAddress.CustomerAddressId,
                        Address = (customerAddress.Address ?? string.Empty),
                        Name = (customerAddress.Name ?? string.Empty),
                        Telephone = (customerAddress.Telephone ?? string.Empty),
                        IsDefault = customerAddress.IsDefault ?? false,
                        CityId = customerAddress.CityId,
                        CountyId = customerAddress.CountyId,
                        ProvinceId = customerAddress.ProvinceId,
                        RegionCode = (customerAddress.RegionCode ?? string.Empty),
                        Sex = customerAddress.Sex,
                        AddressBuilding = customerAddress.AddressBuilding ?? string.Empty,
                        AddressDetail = customerAddress.AddressDetail ?? string.Empty,
                        AddressAlias = customerAddress.AddressAlias ?? string.Empty
                    }).ToList();

            var result = new Customer
                {
                    UserId = getUserResult.Result.UserId,
                    UserName = (getUserResult.Result.UserName ?? string.Empty),
                    Avatar = (getUserResult.Result.Avatar ?? string.Empty),
                    Email = (getUserResult.Result.Email ?? string.Empty),
                    Telephone = (getUserResult.Result.Telephone ?? string.Empty),
                    SupplierId = getUserResult.Result.SupplierId,
                    CustomerAddressList = customerAddressList
                };

            return new Response<Customer>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getUserResult.StatusCode
                        },
                    Result = result
                };
        }



        /// <summary>
        /// 获取用户所下订单金额占当前集团订单总金额的百分比
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="supplierGroupId">The supplierGroupId</param>
        /// <returns>
        /// Double}
        /// </returns>
        /// 创建者：李红杰
        /// 创建日期：2014/9/9 11:31
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        [TokenFilter]
        public Response<string> GetUserWaiMaiOrderPercentage(int id, int supplierGroupId, int orderId)
        {
            if (!this.ValidateUserId(id))
            {
                return new Response<string>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int) StatusCode.OAuth.AccessDenied
                            },
                        Result = "0%"
                    };
            }

            var getUserResult = this.usersServices.GetUserWaiMaiOrderPercentage(id, supplierGroupId, orderId);
          

            return new Response<string>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getUserResult.StatusCode
                        },
                    Result = getUserResult.Result
                };
        }




        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="type">账号类型 1 邮箱  2 电话</param>
        /// <returns>
        /// The GetUserResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<CustomerSimple> GetUserSimple(string account, int type)
        {
            var getUserSimpleResult = this.usersServices.GetUserSimple(this.Source, account, type);
            if (getUserSimpleResult.Result == null)
            {
                return new Response<CustomerSimple>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getUserSimpleResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getUserSimpleResult.StatusCode
                    },
                    Result = new CustomerSimple()
                };
            }

            var result = new CustomerSimple
            {
                UserId = getUserSimpleResult.Result.UserId,
                Email = (getUserSimpleResult.Result.Email ?? string.Empty),
                Telephone = (getUserSimpleResult.Result.Telephone ?? string.Empty)
            };

            return new Response<CustomerSimple>
            {
                Message = new ApiMessage
                {
                    StatusCode = getUserSimpleResult.StatusCode
                },
                Result = result
            };
        }

        /// <summary>
        /// 取得用户地址
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="customerAddressId">用户地址Id</param>
        /// <returns>
        /// The CustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:41
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        [TokenFilter]
        public Response<CustomerAddress> CustomerAddress(int id, int customerAddressId)
        {
            if (!this.ValidateUserId(id))
            {
                return new Response<CustomerAddress>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new CustomerAddress()
                };
            }

            var saveCustomerAddressResult = this.usersServices.GetCustomerAddress(this.Source, id, customerAddressId);
            var customerAddress = new CustomerAddress
            {
                CustomerAddressId = saveCustomerAddressResult.Result.CustomerAddressId,
                Address = (saveCustomerAddressResult.Result.Address ?? string.Empty),
                Name = (saveCustomerAddressResult.Result.Name ?? string.Empty),
                Telephone = (saveCustomerAddressResult.Result.Telephone ?? string.Empty),
                IsDefault = saveCustomerAddressResult.Result.IsDefault ?? false,
                CityId = saveCustomerAddressResult.Result.CityId,
                CountyId = saveCustomerAddressResult.Result.CountyId,
                ProvinceId = saveCustomerAddressResult.Result.ProvinceId,
                RegionCode = (saveCustomerAddressResult.Result.RegionCode ?? string.Empty),
                Sex = saveCustomerAddressResult.Result.Sex,
                AddressBuilding = saveCustomerAddressResult.Result.AddressBuilding ?? string.Empty,
                AddressDetail = saveCustomerAddressResult.Result.AddressDetail ?? string.Empty,
                AddressAlias = saveCustomerAddressResult.Result.AddressAlias ?? string.Empty
            };

            return new Response<CustomerAddress>
            {
                Message = new ApiMessage
                {
                    StatusCode = saveCustomerAddressResult.StatusCode,
                },
                Result = customerAddress
            };
        }

        /// <summary>
        /// 取得用户地址
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="cityId">The cityId</param>
        /// <returns>
        /// The CustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:41
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        [TokenFilter]
        public ListResponse<CustomerAddress> CustomerAddressList(int id, int? cityId = null)
        {
            if (!this.ValidateUserId(id))
            {
                return new ListResponse<CustomerAddress>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new List<CustomerAddress>()
                };
            }

            var list = this.usersServices.GetCustomerAddressList(this.Source, id, cityId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<CustomerAddress>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<CustomerAddress>()
                };
            }

            var customerAddressList = list.Result.Select(p => new CustomerAddress
            {
                CustomerAddressId = p.CustomerAddressId,
                Address = (p.Address ?? string.Empty),
                Name = (p.Name ?? string.Empty),
                Telephone = (p.Telephone ?? string.Empty),
                IsDefault = p.IsDefault ?? false,
                CityId = p.CityId,
                CountyId = p.CountyId,
                ProvinceId = p.ProvinceId,
                RegionCode = (p.RegionCode ?? string.Empty),
                Sex = p.Sex,
                AddressBuilding = p.AddressBuilding ?? string.Empty,
                AddressDetail = p.AddressDetail ?? string.Empty,
                AddressAlias = p.AddressAlias ?? string.Empty
            }).ToList();

            return new ListResponse<CustomerAddress>
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode,
                },
                Result = customerAddressList
            };
        }

        /// <summary>
        /// 保存用户地址
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
        [TokenFilter]
        public Response<SaveCustomerAddressModel> CustomerAddress(int id, CustomerAddressRequst requst)
        {
            if (requst == null)
            {
                return new Response<SaveCustomerAddressModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (!this.ValidateUserId(id))
            {
                return new Response<SaveCustomerAddressModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            var result = this.usersServices.SaveCustomerAddress(this.Source, id, new CustomerAddressParameter
                {
                    CustomerAddressId = requst.CustomerAddressId,
                    Name = (requst.Name ?? string.Empty).Trim(),
                    Address = (requst.Address ?? string.Empty).Trim(),
                    AddressAlias = (requst.AddressAlias ?? string.Empty).Trim(),
                    IsDefault = requst.IsDefault,
                    RegionCode = (requst.RegionCode ?? string.Empty).Trim(),
                    Sex = requst.Sex,
                    Telephone = (requst.Telephone ?? string.Empty).Trim(),
                    AddressBuilding = (requst.AddressBuilding ?? string.Empty).Trim(),
                    AddressDetail = (requst.AddressDetail ?? string.Empty).Trim()
                });

            return new Response<SaveCustomerAddressModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 保存用户地址
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
        [TokenFilter]
        public Response<string> InsertCustomerAddress(int id, CustomerAddressRequst requst)
        {
            if (requst == null)
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (!this.ValidateUserId(id))
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            var result = this.usersServices.InsertCustomerAddress(this.Source, id, new CustomerAddressParameter
            {
                CustomerAddressId = requst.CustomerAddressId,
                Name = (requst.Name ?? string.Empty).Trim(),
                Address = (requst.Address ?? string.Empty).Trim(),
                AddressAlias = (requst.AddressAlias ?? string.Empty).Trim(),
                IsDefault = requst.IsDefault,
                RegionCode = (requst.RegionCode ?? string.Empty).Trim(),
                Sex = requst.Sex,
                Telephone = (requst.Telephone ?? string.Empty).Trim(),
                AddressBuilding = (requst.AddressBuilding ?? string.Empty).Trim(),
                AddressDetail = (requst.AddressDetail ?? string.Empty).Trim()
            });

            return new Response<string>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
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
        [TokenFilter]
        public Response<bool> DeleteCustomerAddress(int id, List<int> customerAddressIdList)
        {
            if (customerAddressIdList == null || customerAddressIdList.Count == 0)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

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

            var result = this.usersServices.DeleteCustomerAddress(this.Source, id, customerAddressIdList);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 设置默认用户地址
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="customerAddressId">用户地址Id</param>
        /// <returns>
        /// The SetDefaultCustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        [TokenFilter]
        public Response<bool> SetDefaultCustomerAddress(int id, int customerAddressId)
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

            var result = this.usersServices.SetDefaultCustomerAddress(this.Source, id, customerAddressId);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
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
        public Response<RegisterUserResult> Register(RegisterUserRequst requst)
        {
            if (requst == null)
            {
                return new Response<RegisterUserResult>
                {
                    Result = new RegisterUserResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var registerResult = this.usersServices.Register(this.Source, new RegisterUserParameter
                {
                    UserId = requst.UserId,
                    Email = (requst.Email ?? string.Empty).Trim(),
                    Telephone = (requst.Telephone ?? string.Empty).Trim(),
                    Password = (requst.Password ?? string.Empty).Trim(),
                    AuthCode = (requst.AuthCode ?? string.Empty).Trim(),
                    AppKey = (this.AppKey ?? string.Empty).Trim(),
                    SourceType = (requst.SourceType ?? string.Empty).Trim(),
                    Template = (requst.Template ?? string.Empty).Trim(),
                    SmsSource = requst.SmsSource,
                    SupplierId = requst.SupplierId,
                    IsVoiceSms = requst.IsVoiceSms
                });

            if (registerResult.Result == null)
            {
                return new Response<RegisterUserResult>
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
                AccessToken = (registerResult.Result.AccessToken ?? string.Empty),
                RefreshToken = (registerResult.Result.RefreshToken ?? string.Empty),
                TokenType = (registerResult.Result.TokenType ?? string.Empty)
            };

            return new Response<RegisterUserResult>
            {
                Message = new ApiMessage
                {
                    StatusCode = registerResult.StatusCode
                },
                Result = result
            };
        }

        /// <summary>
        /// 第三方登录注册用户
        /// </summary>
        /// <param name="requst">The requstDefault documentation</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/17/2014 5:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<RegisterUserResult> RegisterOAuth(RegisterUserOAuthRequst requst)
        {
            if (requst == null)
            {
                return new Response<RegisterUserResult>
                {
                    Result = new RegisterUserResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var registerResult = this.usersServices.RegisterOAuth(this.Source, new RegisterUserOAuthParameter
            {
                AppKey = (this.AppKey ?? string.Empty).Trim(),
                SourceType = (requst.SourceType ?? string.Empty).Trim(),
                Template = (requst.Template ?? string.Empty).Trim(),
                JointLoginType = requst.JointLoginType,
                KeyName = (requst.KeyName ?? string.Empty).Trim(),
                UserName = (requst.UserName ?? string.Empty).Trim()
            });

            if (registerResult.Result == null)
            {
                return new Response<RegisterUserResult>
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
                AccessToken = (registerResult.Result.AccessToken ?? string.Empty),
                RefreshToken = (registerResult.Result.RefreshToken ?? string.Empty),
                TokenType = (registerResult.Result.TokenType ?? string.Empty)
            };

            return new Response<RegisterUserResult>
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
        /// <param name="supplierGroupId">The supplierGroupId</param>
        /// <param name="platformId">平台Id</param>
        /// <returns>
        /// The FollowerSupplierListResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        [TokenFilter]
        public ListResponse<FollowerSupplier> FollowerSupplierList(int id, int? supplierGroupId = null, int? platformId = null)
        {
            if (!this.ValidateUserId(id))
            {
                return new ListResponse<FollowerSupplier>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new List<FollowerSupplier>()
                };
            }

            var list = this.usersServices.GetFollowerSupplierList(this.Source, id, supplierGroupId, this.IsEtaoshi, platformId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<FollowerSupplier>
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
                    SupplierName = (p.SupplierName ?? string.Empty),
                    SupplierDescription = (p.SupplierDescription ?? string.Empty),
                    Address = (p.Address ?? string.Empty),
                    Averageprice = p.Averageprice ?? 0,
                    AverageRating = p.AverageRating,
                    CuisineName = (p.CuisineName ?? string.Empty),
                    LogoUrl = (p.LogoUrl ?? string.Empty),
                    Telephone = (p.Telephone ?? string.Empty),
                    SupplierFeatureList = p.SupplierFeatureList.Select(q => new SupplierFeature
                    {
                        SupplierFeatureId = q.SupplierFeatureId,
                        FeatureId = q.FeatureId,
                        FeatureName = q.FeatureName ?? string.Empty
                    }).ToList()
                }).ToList();

            return new ListResponse<FollowerSupplier>
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                ResultTotalCount = list.ResultTotalCount,
                Result = result
            };
        }

        /// <summary>
        /// 判定是否已经收藏餐厅
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="supplierId">The supplierId</param>
        /// <returns>
        /// The IsFollowerSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        [TokenFilter]
        public Response<bool> IsFollowerSupplier(int id, int supplierId)
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

            var result = this.usersServices.IsFollowerSupplier(this.Source, id, supplierId);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
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
        [TokenFilter]
        public Response<bool> AddFollowerSupplier(int id, List<int> supplierIdList)
        {
            if (supplierIdList == null || supplierIdList.Count == 0)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

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

            var result = this.usersServices.AddFollowerSupplier(this.Source, id, supplierIdList);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
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
        [TokenFilter]
        public Response<bool> DeleteFollowerSupplier(int id, List<int> supplierIdList)
        {
            if (supplierIdList == null || supplierIdList.Count == 0)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

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

            var result = this.usersServices.DeleteFollowerSupplier(this.Source, id, supplierIdList);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        /// <summary>
        /// 用户订单列表
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="orderType">订单类型</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierGroupId">餐厅群组Id</param>
        /// <param name="paidStatus">支付状态</param>
        /// <param name="pageSize">每页最大数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="cancelled">The  cancelled indicates whether</param>
        /// <param name="platformId">平台Id</param>
        /// <returns>
        /// UserOrderListResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 14:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        [TokenFilter]
        public ListResponse<IOrderModel> UserOrderList(int id, int orderType = -1, int? orderStatus = null, int? supplierId = null,
                                                       int? supplierGroupId = null, bool? paidStatus = null, int pageSize = 10, int? pageIndex = null,
                                                        bool cancelled = false, int? platformId = null)
        {
            if (!this.ValidateUserId(id))
            {
                return new ListResponse<IOrderModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new List<IOrderModel>()
                };
            }

            var list = this.usersServices.GetUserOrderList(this.Source, id, (OrderType) orderType,
                                                           new GetUserOrderParameter
                                                               {
                                                                   OrderStatus = orderStatus,
                                                                   PaidStatus = paidStatus,
                                                                   SupplierId = supplierId == 0 ? null : supplierId,
                                                                   SupplierGroupId =supplierGroupId == 0 ? null : supplierGroupId,
                                                                   IsEtaoshi = supplierGroupId == 17 ? false : this.IsEtaoshi,
                                                                   PageIndex = pageIndex,
                                                                   PageSize = pageSize,
                                                                   Cancelled = cancelled,
                                                                   PlatformId = platformId
                                                               });

            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<IOrderModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<IOrderModel>()
                };
            }

            //var result = list.Result.Select(p => new UserOrder
            //{
            //    OrderId = p.OrderId,
            //    SupplierId = p.SupplierId ?? 0,
            //    SupplierName = (p.SupplierName ?? string.Empty),
            //    DateReserved = p.DateReserved == null ? string.Empty : p.DateReserved.Value.ToString("yyyy-MM-dd HH:mm"),
            //    CustomerTotal = p.CustomerTotal ?? 0,
            //    OrderStatusId = p.OrderStatusId ?? 0,
            //    OrderStatus = (p.OrderStatus ?? string.Empty),
            //    OrderType = p.OrderType,
            //    DineNumber = p.DineNumber ?? 0,
            //    DeliveryMethodId = p.DeliveryMethodId,
            //    IsPaid = p.IsPaid ?? false,
            //    DishNames = p.DishNames,
            //    PaymentMethodId = p.PaymentMethodId ?? -1
            //}).ToList();

            var result = list.Result;
            return new ListResponse<IOrderModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                ResultTotalCount = list.ResultTotalCount,
                Result = result
            };
        }

        [HttpPost]
        [TokenFilter]
        public Response<bool> SaveFeedback(SaveFeedbackParameter saveFeedbackParameter)
        {
            var result = this.usersServices.SaveFeedback(saveFeedbackParameter);

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