namespace Ets.SingleApi.Services.DetailServices
{
    using System;
    using System.Linq;

    using Castle.Services.Transaction;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.DetailServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：UsersDetailServices
    /// 命名空间：Ets.SingleApi.Services.DetailServices
    /// 类功能：用户功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 8:10 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Transactional]
    public class UsersDetailServices : IUsersDetailServices
    {
        /// <summary>
        /// 字段autorizationEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/24/2013 7:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<AppEntity> appEntityRepository;

        /// <summary>
        /// 字段tokenEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/24/2013 7:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TokenEntity> tokenEntityRepository;

        /// <summary>
        /// 字段loginEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段sourceTypeEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SourceTypeEntity> sourceTypeEntityRepository;

        /// <summary>
        /// 字段loginOAuthEntityRepository
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：2/17/2014 5:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginOAuthEntity> loginOAuthEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersDetailServices" /> class.
        /// </summary>
        /// <param name="appEntityRepository">The appEntityRepository</param>
        /// <param name="tokenEntityRepository">The tokenEntityRepository</param>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="sourceTypeEntityRepository">The sourceTypeEntityRepository</param>
        /// <param name="loginOAuthEntityRepository"></param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UsersDetailServices(
            INHibernateRepository<AppEntity> appEntityRepository,
            INHibernateRepository<TokenEntity> tokenEntityRepository,
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SourceTypeEntity> sourceTypeEntityRepository,
            INHibernateRepository<LoginOAuthEntity> loginOAuthEntityRepository)
        {
            this.appEntityRepository = appEntityRepository;
            this.tokenEntityRepository = tokenEntityRepository;
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.sourceTypeEntityRepository = sourceTypeEntityRepository;
            this.loginOAuthEntityRepository = loginOAuthEntityRepository;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<RegisterUserModel> Register(RegisterUserParameter parameter)
        {
            if (parameter == null)
            {
                return new DetailServicesResult<RegisterUserModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new RegisterUserModel()
                };
            }

            var appEntity = this.appEntityRepository.EntityQueryable.FirstOrDefault(p => p.AppKey == parameter.AppKey);
            if (appEntity == null)
            {
                return new DetailServicesResult<RegisterUserModel>
                {
                    Result = new RegisterUserModel(),
                    StatusCode = (int)StatusCode.OAuth.InvalidClient
                };
            }

            var password = parameter.Password.IsEmptyOrNull() ? string.Empty : parameter.Password;
            var loginEntity = new LoginEntity
            {
                Username = parameter.Telephone,
                Password = password.Md5(),
                Level = new LevelEntity
                {
                    LevelId = (int)UserLevel.User
                },
                IsEnabled = true
            };

            this.loginEntityRepository.Save(loginEntity);

            var loginId = loginEntity.LoginId;
            var customerEntity = new CustomerEntity
            {
                Mobile = parameter.Telephone,
                Email = parameter.Email.IsEmptyOrNull() ? null : parameter.Email,
                LoginId = loginId,
                Forename = string.Empty,
                DateJoined = DateTime.Now,
                IsValId = false,
                IsRegAllowed = true,
                Source = parameter.SourceType.IsEmptyOrNull() ? null : this.sourceTypeEntityRepository.FindSingleByExpression(p => p.Value == parameter.SourceType),
                TemplateId = parameter.Template
            };

            this.customerEntityRepository.Save(customerEntity);

            var accessToken = Guid.NewGuid().ToString("N");
            var refreshToken = Guid.NewGuid().ToString("N");
            var tokenEntity = new TokenEntity
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AppKey = appEntity,
                CreatedTime = DateTime.Now,
                UserId = loginId
            };

            this.tokenEntityRepository.Save(tokenEntity);

            return new DetailServicesResult<RegisterUserModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new RegisterUserModel
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken,
                        UserId = loginId,
                        TokenType = CommonUtility.GetTokenType()
                    }
                };
        }

        /// <summary>
        /// 第三方登录注册用户
        /// </summary>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// DetailServicesResult{RegisterUserModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/17/2014 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<RegisterUserModel> RegisterOAuth(RegisterUserOAuthParameter parameter)
        {
            if (parameter == null)
            {
                return new DetailServicesResult<RegisterUserModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new RegisterUserModel()
                };
            }

            //查询 AppKey是否有效
            var appEntity = this.appEntityRepository.EntityQueryable.FirstOrDefault(p => p.AppKey == parameter.AppKey);
            if (appEntity == null)
            {
                return new DetailServicesResult<RegisterUserModel>
                {
                    Result = new RegisterUserModel(),
                    StatusCode = (int)StatusCode.OAuth.InvalidClient
                };
            }

            var loginEntity = new LoginEntity
            {
                Username = parameter.KeyName,
                Password = CommonUtility.RandNum(6).Md5(),
                Level = new LevelEntity
                {
                    LevelId = (int)UserLevel.User
                },
                IsEnabled = true
            };

            //保存Login
            this.loginEntityRepository.Save(loginEntity);

            var loginOAuthEntity = new LoginOAuthEntity
            {
                Login = loginEntity,
                JointLoginType = parameter.JointLoginType,
                KeyName = parameter.KeyName,
                SafeCode = null
            };

            //保存 LoginOAuth
            this.loginOAuthEntityRepository.Save(loginOAuthEntity);

            var loginId = loginEntity.LoginId;
            var customerEntity = new CustomerEntity
            {
                Mobile = parameter.KeyName,
                Email = null,
                LoginId = loginId,
                Forename = string.Empty,
                DateJoined = DateTime.Now,
                IsValId = false,
                IsRegAllowed = true,
                Source = parameter.SourceType.IsEmptyOrNull() ? null : this.sourceTypeEntityRepository.FindSingleByExpression(p => p.Value == parameter.SourceType),
                TemplateId = parameter.Template
            };

            //保存Customer
            this.customerEntityRepository.Save(customerEntity);

            var accessToken = Guid.NewGuid().ToString("N");
            var refreshToken = Guid.NewGuid().ToString("N");
            var tokenEntity = new TokenEntity
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AppKey = appEntity,
                CreatedTime = DateTime.Now,
                UserId = loginId
            };

            //保存Token
            this.tokenEntityRepository.Save(tokenEntity);

            return new DetailServicesResult<RegisterUserModel>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = new RegisterUserModel
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    UserId = loginId,
                    TokenType = CommonUtility.GetTokenType()
                }
            };
        }
    }
}