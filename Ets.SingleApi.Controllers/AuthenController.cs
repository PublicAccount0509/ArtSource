﻿namespace Ets.SingleApi.Controllers
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
        public Response<LoginResult> Login(LoginRequst requst)
        {
            if (requst == null)
            {
                return new Response<LoginResult>
                    {
                        Result = new LoginResult(),
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.System.InvalidRequest
                            }
                    };
            }

            if (requst.Telephone.IsEmptyOrNull() && requst.Email.IsEmptyOrNull())
            {
                return new Response<LoginResult>
                {
                    Result = new LoginResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                    }
                };
            }

            if (requst.Password.IsEmptyOrNull())
            {
                return new Response<LoginResult>
                {
                    Result = new LoginResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidAuthCode
                    }
                };
            }

            var loginResult = this.authenServices.Login(this.Source, new LoginParameter
                        {
                            Email = (requst.Email ?? string.Empty).Trim(),
                            Password = (requst.Password ?? string.Empty).Trim(),
                            Telephone = (requst.Telephone ?? string.Empty).Trim(),
                            AppKey = (this.AppKey ?? string.Empty).Trim()
                        });

            if (loginResult.Result == null)
            {
                return new Response<LoginResult>
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
                    AccessToken = loginResult.Result.AccessToken ?? string.Empty,
                    RefreshToken = loginResult.Result.RefreshToken ?? string.Empty,
                    TokenType = loginResult.Result.TokenType ?? string.Empty
                };

            return new Response<LoginResult>
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
        public Response<AuthLoginResult> AuthLogin(AuthLoginRequst requst)
        {
            if (requst == null)
            {
                return new Response<AuthLoginResult>
                {
                    Result = new AuthLoginResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (requst.Telephone.IsEmptyOrNull())
            {
                return new Response<AuthLoginResult>
                {
                    Result = new AuthLoginResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                    }
                };
            }

            if (requst.AuthCode.IsEmptyOrNull())
            {
                return new Response<AuthLoginResult>
                {
                    Result = new AuthLoginResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidAuthCode
                    }
                };
            }

            var loginResult = this.authenServices.AuthLogin(this.Source, new AuthLoginParameter
            {
                Telephone = (requst.Telephone ?? string.Empty).Trim(),
                AuthCode = (requst.AuthCode ?? string.Empty).Trim(),
                AppKey = (this.AppKey ?? string.Empty).Trim()
            });

            if (loginResult.Result == null)
            {
                return new Response<AuthLoginResult>
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
                AccessToken = loginResult.Result.AccessToken ?? string.Empty,
                RefreshToken = loginResult.Result.RefreshToken ?? string.Empty,
                TokenType = loginResult.Result.TokenType ?? string.Empty
            };

            return new Response<AuthLoginResult>
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

        [HttpPost]
        public Response<OAuthLoginResult> OAuthLogin(OAuthLoginRequst requst)
        {
            if (requst == null)
            {
                return new Response<OAuthLoginResult>
                {
                    Result = new OAuthLoginResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (requst.KeyName.IsEmptyOrNull())
            {
                return new Response<OAuthLoginResult>
                {
                    Result = new OAuthLoginResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                    }
                };
            }

            var loginResult = this.authenServices.OAuthLogin(this.Source, new OAuthLoginParameter
            {
                KeyName = (requst.KeyName ?? string.Empty).Trim(),
                AppKey = (this.AppKey ?? string.Empty).Trim()
            });

            if (loginResult.Result == null)
            {
                return new Response<OAuthLoginResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = loginResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : loginResult.StatusCode
                    },
                    Result = new OAuthLoginResult()
                };
            }

            var result = new OAuthLoginResult
            {
                UserId = loginResult.Result.UserId,
                AccessToken = loginResult.Result.AccessToken ?? string.Empty,
                RefreshToken = loginResult.Result.RefreshToken ?? string.Empty,
                TokenType = loginResult.Result.TokenType ?? string.Empty
            };

            return new Response<OAuthLoginResult>
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
        public Response<bool> Password(int id, PasswordRequst requst)
        {
            if (requst == null)
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

            var result = this.authenServices.Password(this.Source, id, new PasswordParameter
            {
                OldPassword = (requst.OldPassword ?? string.Empty).Trim(),
                NewPasswrod = (requst.NewPasswrod ?? string.Empty).Trim(),
                IsSendSms = requst.IsSendSms,
                SmsSource = requst.SmsSource,
                SupplierId = requst.SupplierId,
                IsVoiceSms = requst.IsVoiceSms
            });

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
        /// 修改密码
        /// </summary>
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
        public Response<bool> SetPassword(SetPasswordRequst requst)
        {
            if (requst == null)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var result = this.authenServices.SetPassword(this.Source, new SetPasswordParameter
            {
                UserName = (requst.UserName ?? string.Empty).Trim(),
                AuthCode = (requst.AuthCode ?? string.Empty).Trim(),
                NewPasswrod = (requst.NewPasswrod ?? string.Empty).Trim(),
                IsSendSms = requst.IsSendSms,
                SmsSource = requst.SmsSource,
                SupplierId = requst.SupplierId,
                IsVoiceSms = requst.IsVoiceSms
            });

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
        /// 找回密码
        /// </summary>
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
        public Response<bool> FindPassword(FindPasswordRequst requst)
        {
            if (requst == null)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (requst.WayList == null || requst.WayList.Count == 0)
            {
                return new Response<bool>
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

            var result = this.authenServices.FindPassword(this.Source, new FindPasswordParameter
            {
                UserName = (requst.UserName ?? string.Empty).Trim(),
                WayList = wayList,
                SmsSource = requst.SmsSource,
                SupplierId = requst.SupplierId,
                IsVoiceSms = requst.IsVoiceSms
            });

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
        /// 验证验证码
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// The AuthCodeResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> AuthCode(AuthCodeRequst requst)
        {
            if (requst == null)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var result = this.authenServices.AuthCode(this.Source, new AuthCodeParameter
            {
                Telephone = (requst.Telephone ?? string.Empty).Trim(),
                AuthCode = (requst.AuthCode ?? string.Empty).Trim()
            });

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