namespace Ets.SingleApi.Services.DetailServices
{
    using System;

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
        /// Initializes a new instance of the <see cref="UsersDetailServices" /> class.
        /// </summary>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="sourceTypeEntityRepository">The sourceTypeEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UsersDetailServices(
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SourceTypeEntity> sourceTypeEntityRepository)
        {
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.sourceTypeEntityRepository = sourceTypeEntityRepository;
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
        public DetailServicesResult<int> Register(RegisterUserParameter parameter)
        {
            if (parameter == null)
            {
                return new DetailServicesResult<int>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
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
                Email = parameter.Email,
                LoginId = loginId,
                Forename = string.Empty,
                DateJoined = DateTime.Now,
                IsValId = false,
                IsRegAllowed = true,
                Source = parameter.SourceType.IsEmptyOrNull() ? null : this.sourceTypeEntityRepository.FindSingleByExpression(p => p.Value == parameter.SourceType)
            };

            this.customerEntityRepository.Save(customerEntity);
            return new DetailServicesResult<int>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = loginId
                };
        }
    }
}