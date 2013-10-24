namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：EmailLogin
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：用电子邮箱登录
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 10:00
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EmailLogin : ILogin
    {
        /// <summary>
        /// 字段loginEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:16
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneLogin" /> class.
        /// </summary>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EmailLogin(
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository)
        {
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
        }

        /// <summary>
        /// 登陆方式
        /// </summary>
        /// <value>
        /// 返回登陆方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public LoginWay LoginWay
        {
            get
            {
                return LoginWay.Email;
            }
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password</param>
        /// <returns>
        /// 返回登陆结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public LoginData Login(string userName, string password)
        {
            var customer = this.customerEntityRepository.EntityQueryable.FirstOrDefault(p => p.Email == userName);
            if (customer == null || !customer.LoginId.HasValue)
            {
                return new LoginData { StatusCode = (int)StatusCode.Validate.InvalidUserNameCode };
            }

            if (password.IsEmptyOrNull())
            {
                return new LoginData { StatusCode = (int)StatusCode.Validate.InvalidPasswordCode };
            }

            password = password.Md5();
            return this.loginEntityRepository.EntityQueryable.Any(
                    p => p.LoginId == customer.LoginId && p.Password == password && p.IsEnabled)
                    ? new LoginData { LoginId = customer.LoginId.Value }
                    : new LoginData { StatusCode = (int)StatusCode.Validate.InvalidPasswordCode };
        }
    }
}