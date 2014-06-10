using System;

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
        /// <param name="source">The source</param>
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
        public LoginData Login(string source, string userName, string password)
        {
            if (password.IsEmptyOrNull())
            {
                return new LoginData { StatusCode = (int)StatusCode.Validate.InvalidPasswordCode };
            }

            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.Email == userName)
                   .Select(p => new { p.LoginId })
                   .FirstOrDefault();
            if (customer == null)
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                };
            }

            var loginId = customer.LoginId;
            var loginEntity = this.loginEntityRepository.EntityQueryable.Where(p => p.LoginId == loginId).Select(p => new { p.LoginId, p.Password, p.IsEnabled }).FirstOrDefault();
            if (loginEntity == null)
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                };
            }

            password = password.Md5();
            //密码校验不区分大小写
            if (!string.Equals(loginEntity.Password, password, StringComparison.OrdinalIgnoreCase))
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.Validate.InvalidPasswordCode
                };
            }

            if (!loginEntity.IsEnabled)
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.General.ErrorPermission
                };
            }

            return new LoginData { LoginId = loginEntity.LoginId };
        }
    }
}