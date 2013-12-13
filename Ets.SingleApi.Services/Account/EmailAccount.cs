namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：EmailAccount
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：验证邮箱存在
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/31/2013 12:20 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EmailAccount : IAccount
    {
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
        /// 账号类型
        /// </summary>
        /// <value>
        /// 账号类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AccountType AccountType
        {
            get
            {
                return AccountType.Email;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAccount" /> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EmailAccount(
            INHibernateRepository<CustomerEntity> customerEntityRepository)
        {
            this.customerEntityRepository = customerEntityRepository;
        }

        /// <summary>
        /// 取得用户信息
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
        public AccountData GetCustomer(string account)
        {
            if (account.IsEmptyOrNull())
            {
                return new AccountData();
            }

            var customer = this.customerEntityRepository.EntityQueryable.FirstOrDefault(p => p.Email == account);
            if (customer == null)
            {
                return new AccountData();
            }

            return new AccountData
                {
                    UserId = customer.LoginId,
                    Email = customer.Email,
                    Telephone = customer.Mobile
                };
        }
    }
}