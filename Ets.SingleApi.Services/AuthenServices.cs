namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：AuthenServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：权限验证
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 0:15
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuthenServices : IAuthenServices
    {
        /// <summary>
        /// 字段appEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 11:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<AppEntity> appEntityRepository;

        /// <summary>
        /// 字段tokenEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 11:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TokenEntity> tokenEntityRepository;

        /// <summary>
        /// 字段loginEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:51
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/5/2013 5:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段smsDetailServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISmsDetailServices smsDetailServices;

        /// <summary>
        /// 字段loginList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<ILogin> loginList;

        /// <summary>
        /// 字段sendPasswordList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:31
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<ISendPassword> sendPasswordList;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenServices" /> class.
        /// </summary>
        /// <param name="appEntityRepository">The appEntityRepository</param>
        /// <param name="tokenEntityRepository">The tokenEntityRepository</param>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="smsDetailServices">The smsDetailServices</param>
        /// <param name="loginList">The loginList</param>
        /// <param name="sendPasswordList">The sendPasswordList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AuthenServices(
            INHibernateRepository<AppEntity> appEntityRepository,
            INHibernateRepository<TokenEntity> tokenEntityRepository,
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            ISmsDetailServices smsDetailServices,
            List<ILogin> loginList,
            List<ISendPassword> sendPasswordList)
        {
            this.appEntityRepository = appEntityRepository;
            this.tokenEntityRepository = tokenEntityRepository;
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.smsDetailServices = smsDetailServices;
            this.loginList = loginList;
            this.sendPasswordList = sendPasswordList;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回登陆结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<LoginModel> Login(LoginParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<LoginModel>
                {
                    Result = new LoginModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var loginWay = this.GetLoginWay(parameter);
            if (loginWay == LoginWay.UnKnow)
            {
                return new ServicesResult<LoginModel>
                    {
                        Result = new LoginModel(),
                        StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                    };
            }

            var userName = this.GetUserName(parameter, loginWay);
            if (userName.IsEmptyOrNull())
            {
                return new ServicesResult<LoginModel>
                    {
                        Result = new LoginModel(),
                        StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                    };
            }

            var login = this.loginList.FirstOrDefault(p => p.LoginWay == loginWay);
            if (login == null)
            {
                return new ServicesResult<LoginModel>
                    {
                        StatusCode = (int)StatusCode.General.UnknowError,
                        Result = new LoginModel()
                    };
            }

            var loginData = login.Login(userName, parameter.Password);
            if (loginData.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<LoginModel>
                {
                    Result = new LoginModel(),
                    StatusCode = loginData.StatusCode
                };
            }

            var appEntity = this.appEntityRepository.EntityQueryable.FirstOrDefault(p => p.AppKey == parameter.AppKey);
            if (appEntity == null)
            {
                return new ServicesResult<LoginModel>
                {
                    Result = new LoginModel(),
                    StatusCode = (int)StatusCode.OAuth.InvalidClient
                };
            }

            var accessToken = Guid.NewGuid().ToString("N");
            var refreshToken = Guid.NewGuid().ToString("N");
            var tokenEntity = new TokenEntity
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    AppKey = appEntity,
                    CreatedTime = DateTime.Now,
                    UserId = loginData.LoginId
                };

            this.tokenEntityRepository.Save(tokenEntity);

            return new ServicesResult<LoginModel>
                {
                    Result = new LoginModel
                        {
                            AccessToken = accessToken,
                            RefreshToken = refreshToken,
                            UserId = loginData.LoginId,
                            TokenType = CommonUtility.GetTokenType()
                        }
                };
        }

        /// <summary>
        /// 手机验证登陆
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回登陆结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/24/2013 4:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<AuthLoginModel> AuthLogin(AuthLoginParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<AuthLoginModel>
                {
                    Result = new AuthLoginModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var login = this.loginList.FirstOrDefault(p => p.LoginWay == LoginWay.AuthTele);
            if (login == null)
            {
                return new ServicesResult<AuthLoginModel>
                {
                    StatusCode = (int)StatusCode.General.UnknowError,
                    Result = new AuthLoginModel()
                };
            }

            var loginData = login.Login(parameter.Telephone, parameter.AuthCode);
            if (loginData.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<AuthLoginModel>
                {
                    Result = new AuthLoginModel(),
                    StatusCode = loginData.StatusCode
                };
            }

            var appEntity = this.appEntityRepository.EntityQueryable.FirstOrDefault(p => p.AppKey == parameter.AppKey);
            if (appEntity == null)
            {
                return new ServicesResult<AuthLoginModel>
                {
                    Result = new AuthLoginModel(),
                    StatusCode = (int)StatusCode.OAuth.InvalidClient
                };
            }

            var accessToken = Guid.NewGuid().ToString("N");
            var refreshToken = Guid.NewGuid().ToString("N");
            var tokenEntity = new TokenEntity
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AppKey = appEntity,
                CreatedTime = DateTime.Now,
                UserId = loginData.LoginId
            };

            this.tokenEntityRepository.Save(tokenEntity);

            return new ServicesResult<AuthLoginModel>
            {
                Result = new AuthLoginModel
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    UserId = loginData.LoginId,
                    TokenType = CommonUtility.GetTokenType()
                }
            };
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">The userId</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回修改密码结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> Password(int userId, PasswordParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (parameter.OldPassword.IsEmptyOrNull())
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidPasswordCode,
                    Result = false
                };
            }

            if (parameter.NewPasswrod.IsEmptyOrNull())
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.EmptyPasswordCode,
                    Result = false
                };
            }

            var loginEntity = this.loginEntityRepository.EntityQueryable.FirstOrDefault(p => p.LoginId == userId);
            if (loginEntity == null)
            {
                return new ServicesResult<bool>
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                        Result = false
                    };
            }

            var oldPassword = parameter.OldPassword;
            if (!string.Equals(loginEntity.Password, oldPassword.Md5(), StringComparison.OrdinalIgnoreCase))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidPasswordCode,
                    Result = false
                };
            }

            loginEntity.Password = parameter.NewPasswrod.Md5();
            this.loginEntityRepository.Save(loginEntity);

            if (!parameter.IsSendSms)
            {
                return new ServicesResult<bool>
                {
                    Result = true
                };
            }

            var content = string.Format(ServicesCommon.ModifyPasswordMessage, parameter.NewPasswrod);
            var result = this.smsDetailServices.SendSms(loginEntity.Username, content);
            if (result == null)
            {
                return new ServicesResult<bool>
                {
                    Result = true,
                    StatusCode = (int)StatusCode.General.SmsSendError
                };
            }

            return new ServicesResult<bool>
            {
                Result = true,
                StatusCode = result.StatusCode
            };
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回设置密码结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SetPassword(SetPasswordParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var authCode = CacheUtility.GetInstance().Get(string.Format("{0}{1}", ServicesCommon.FindPasswordCodeCacheKey, parameter.UserName));
            if (parameter.AuthCode != (authCode == null ? string.Empty : authCode.ToString()))
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidAuthCode
                };
            }

            if (parameter.NewPasswrod.IsEmptyOrNull())
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.EmptyPasswordCode,
                    Result = false
                };
            }

            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.Mobile == parameter.UserName || p.Email == parameter.UserName)
                            .Select(p => new { p.LoginId })
                            .FirstOrDefault();
            var loginId = customer == null ? null : customer.LoginId;
            var loginEntity = this.loginEntityRepository.EntityQueryable.FirstOrDefault(p => p.LoginId == loginId || p.Username == parameter.UserName);
            if (loginEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = false
                };
            }

            loginEntity.Password = parameter.NewPasswrod.Md5();
            this.loginEntityRepository.Save(loginEntity);

            if (!parameter.IsSendSms)
            {
                return new ServicesResult<bool>
                {
                    Result = true
                };
            }

            var content = string.Format(ServicesCommon.ModifyPasswordMessage, parameter.NewPasswrod);
            var result = this.smsDetailServices.SendSms(loginEntity.Username, content);
            if (result == null)
            {
                return new ServicesResult<bool>
                {
                    Result = true,
                    StatusCode = (int)StatusCode.General.SmsSendError
                };
            }

            return new ServicesResult<bool>
            {
                Result = true,
                StatusCode = result.StatusCode
            };
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回找回密码结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> FindPassword(FindPasswordParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (parameter.UserName.IsEmptyOrNull())
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                };
            }


            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.Mobile == parameter.UserName || p.Email == parameter.UserName)
                            .Select(p => new { p.LoginId })
                            .FirstOrDefault();
            var loginId = customer == null ? null : customer.LoginId;
            if (!this.loginEntityRepository.EntityQueryable.Any(p => p.LoginId == loginId || p.Username == parameter.UserName))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserNameCode,
                    Result = false
                };
            }

            var sendTypeList = parameter.WayList.Select(p => p.AccountType).ToList();
            if (!this.sendPasswordList.Any(p => sendTypeList.Contains(p.SendType)))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.General.InvalidFindPasswordWay,
                    Result = false
                };
            }

            var code = CommonUtility.RandNum(6);
            CacheUtility.GetInstance().Set(string.Format("{0}{1}", ServicesCommon.FindPasswordCodeCacheKey, parameter.UserName), code, DateTime.Now.AddMinutes(ServicesCommon.AuthCodeExpiredTime));

            var sendPasswordResultList =
                (from way in parameter.WayList
                 let sendPassword = this.sendPasswordList.FirstOrDefault(p => p.SendType == way.AccountType)
                 where sendPassword != null
                 select sendPassword.Send(way.AccountNumber, code)).ToList();

            var sendPasswordResult = sendPasswordResultList.FirstOrDefault(p => p.StatusCode != (int)StatusCode.Succeed.Ok) ?? new SendPasswordData
                {
                    Result = true,
                    StatusCode = (int)StatusCode.Succeed.Ok
                };

            return new ServicesResult<bool>
                {
                    Result = sendPasswordResult.Result,
                    StatusCode = sendPasswordResult.StatusCode
                };
        }

        /// <summary>
        /// Gets the login way.
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// LoginWay
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:38
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private LoginWay GetLoginWay(LoginParameter requst)
        {
            if (!requst.Telephone.IsEmptyOrNull())
            {
                return LoginWay.Telephone;
            }

            if (!requst.Email.IsEmptyOrNull())
            {
                return LoginWay.Email;
            }

            return LoginWay.UnKnow;
        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <param name="loginWay">The loginWay</param>
        /// <returns>
        /// 返回用户名
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private string GetUserName(LoginParameter requst, LoginWay loginWay)
        {
            if (loginWay == LoginWay.Telephone)
            {
                return requst.Telephone;
            }

            if (loginWay == LoginWay.Email)
            {
                return requst.Email;
            }

            return string.Empty;
        }
    }
}