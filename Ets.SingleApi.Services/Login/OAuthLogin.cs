namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：AuthTeleLogin
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：第三方登录
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 10:00
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OAuthLogin : ILogin
    {
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

        /// <summary>
        /// 字段loginEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginOAuthEntity> loginOAuthEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/29/2013 10:56 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthTeleLogin" /> class.
        /// </summary>
        /// <param name="loginEntityRepository"></param>
        /// <param name="loginOAuthEntityRepository">The loginOAuthEntityRepositoryDefault documentation</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OAuthLogin(
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<LoginOAuthEntity> loginOAuthEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository)
        {
            this.loginEntityRepository = loginEntityRepository;
            this.loginOAuthEntityRepository = loginOAuthEntityRepository;
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
                return LoginWay.OAuth;
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
            if (userName.IsEmptyOrNull())
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                };
            }

            //第三方登录表
            var loginOAuth = this.loginOAuthEntityRepository.EntityQueryable.Where(p => p.KeyName == userName).Select(p => new { p.Login.LoginId,p.IsRegister }).FirstOrDefault();

            if (loginOAuth == null)
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                };
            }
            var loginId = loginOAuth.LoginId;

            //查看LoginId在Customer表中是否存在
            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == loginId).Select(p => new { LoginId = (int)p.LoginId }).FirstOrDefault();
            if (customer == null)
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                };
            }

            //查看LoginId在login表中是否存在
            var loginEntity = this.loginEntityRepository.EntityQueryable.Where(p => p.LoginId == loginId).Select(p => new { p.LoginId, p.IsEnabled }).FirstOrDefault();
            if (loginEntity == null)
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                };
            }

            if (!loginEntity.IsEnabled)
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.General.ErrorPermission
                };
            }

            return new LoginData
                {
                    LoginId = loginEntity.LoginId,
                    IsRegister = loginOAuth.IsRegister ?? false
                };
        }
    }
}