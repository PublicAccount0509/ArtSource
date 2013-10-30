namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using Ets.SingleApi.Controllers.Filters;
    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：AuthenController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 22:40
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuthenController : SingleApiController
    {
        /// <summary>
        /// 字段authenServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IAuthenServices authenServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenController"/> class.
        /// </summary>
        /// <param name="authenServices">The authenServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AuthenController(IAuthenServices authenServices)
        {
            this.authenServices = authenServices;
        }

        /// <summary>
        /// 登陆方法
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// The LoginResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public LoginResponse Login(LoginRequst requst)
        {
            if (requst == null)
            {
                return new LoginResponse
                    {
                        Result = new LoginResult(),
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.System.InvalidRequest
                            }
                    };
            }

            var loginResult = this.authenServices.Login(new LoginParameter
                        {
                            Email = (requst.Email ?? string.Empty).Trim(),
                            Password = (requst.Password ?? string.Empty).Trim(),
                            Telephone = (requst.Telephone ?? string.Empty).Trim(),
                            AutorizationCode = (this.AutorizationCode ?? string.Empty).Trim()
                        });

            if (loginResult.Result == null)
            {
                return new LoginResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = loginResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : loginResult.StatusCode
                    },
                    Result = new LoginResult()
                };
            }

            var result = new LoginResult
                {
                    UserId = loginResult.Result.UserId,
                    AccessToken = loginResult.Result.AccessToken,
                    RefreshToken = loginResult.Result.RefreshToken,
                    TokenType = loginResult.Result.TokenType
                };

            return new LoginResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = loginResult.StatusCode
                },
                Result = result,
                Cache = new ApiCache
                    {
                        ExpiresIn = CommonUtility.GetTokenExpiresIn()
                    }
            };
        }

        /// <summary>
        /// 手机验证登陆方法
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// The LoginResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public AuthLoginResponse AuthLogin(AuthLoginRequst requst)
        {
            if (requst == null)
            {
                return new AuthLoginResponse
                {
                    Result = new AuthLoginResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var loginResult = this.authenServices.AuthLogin(new AuthLoginParameter
            {
                Telephone = (requst.Telephone ?? string.Empty).Trim(),
                AuthCode = (requst.AuthCode ?? string.Empty).Trim(),
                AutorizationCode = (this.AutorizationCode ?? string.Empty).Trim()
            });

            if (loginResult.Result == null)
            {
                return new AuthLoginResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = loginResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : loginResult.StatusCode
                    },
                    Result = new AuthLoginResult()
                };
            }

            var result = new AuthLoginResult
            {
                UserId = loginResult.Result.UserId,
                AccessToken = loginResult.Result.AccessToken,
                RefreshToken = loginResult.Result.RefreshToken,
                TokenType = loginResult.Result.TokenType
            };

            return new AuthLoginResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = loginResult.StatusCode
                },
                Result = result,
                Cache = new ApiCache
                {
                    ExpiresIn = CommonUtility.GetTokenExpiresIn()
                }
            };
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// The PasswordResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        [TokenFilter]
        public PasswordResponse Password(int id, PasswordRequst requst)
        {
            if (requst == null)
            {
                return new PasswordResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (!this.ValidateUserId(id))
            {
                return new PasswordResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            var passwordResult = this.authenServices.Password(id, new PasswordParameter
            {
                OldPassword = (requst.OldPassword ?? string.Empty).Trim(),
                NewPasswrod = (requst.NewPasswrod ?? string.Empty).Trim(),
                IsSendSms = requst.IsSendSms
            });

            return new PasswordResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = passwordResult.StatusCode
                }
            };
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// The FindPasswordResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        [TokenFilter]
        public FindPasswordResponse FindPassword(int id, FindPasswordRequst requst)
        {
            if (requst == null)
            {
                return new FindPasswordResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (!this.ValidateUserId(id))
            {
                return new FindPasswordResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            if (requst.WayList == null || requst.WayList.Count == 0)
            {
                return new FindPasswordResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var wayList = requst.WayList.Select(p =>
                                        new FindPasswordWayModel
                                            {
                                                AccountNumber = (p.AccountNumber ?? string.Empty).Trim(),
                                                AccountType = (PasswordType)p.AccountType
                                            }).ToList();

            var findPasswordResult = this.authenServices.FindPassword(id, new FindPasswordParameter
            {
                WayList = wayList
            });

            return new FindPasswordResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = findPasswordResult.StatusCode
                }
            };
        }
    }
}