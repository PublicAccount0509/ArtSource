namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：TelephoneExists
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：验证邮箱存在
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/31/2013 12:20 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SocialOAuthExists : IExists
    {
        /// <summary>
        /// 字段loginEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// The login o authentication entity repository
        /// </summary>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-18 15:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginOAuthEntity> loginOAuthEntityRepository;

        /// <summary>
        /// 验证存在的类型
        /// </summary>
        /// <value>
        /// 验证存在的类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ExistsType ExistsType
        {
            get
            {
                return ExistsType.SocialOAuth;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneExists" /> class.
        /// </summary>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="loginOAuthEntityRepository">The login o authentication entity repository.</param>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SocialOAuthExists(
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<LoginOAuthEntity> loginOAuthEntityRepository)
        {
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.loginOAuthEntityRepository = loginOAuthEntityRepository;
        }

        /// <summary>
        /// 验证是否存在
        /// </summary>
        /// <param name="account">The account</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ExistsData Exist(string account)
        {
            if (account.IsEmptyOrNull())
            {
                return new ExistsData();
            }

            var loginOAuth = this.loginOAuthEntityRepository.EntityQueryable.FirstOrDefault(p => p.KeyName == account);
            if (loginOAuth == null)
            {
                return new ExistsData();
            }

            var login = this.loginEntityRepository.EntityQueryable.Where(p => p.LoginId == loginOAuth.Login.LoginId)
                    .Select(p => new { p.LoginId, p.IsEnabled })
                    .FirstOrDefault();

            if (login == null)
            {
                return new ExistsData
                    {
                        Exist = true
                    };
            }

            return new ExistsData
                {
                    Exist = true,
                    Login = login.IsEnabled
                };
        }
    }
}