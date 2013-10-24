﻿namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：AuthTeleLogin
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：用电话号码登录
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 10:00
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuthTeleLogin : ILogin
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
        /// Initializes a new instance of the <see cref="AuthTeleLogin"/> class.
        /// </summary>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AuthTeleLogin(INHibernateRepository<LoginEntity> loginEntityRepository)
        {
            this.loginEntityRepository = loginEntityRepository;
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
                return LoginWay.AuthTele;
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
            var authCode = CacheUtility.GetInstance().Get(string.Format("{0}{1}", ServicesCommon.AuthCodeCacheKey, password));
            if (password != (authCode == null ? string.Empty : authCode.ToString()))
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.Validate.InvalidAuthCode
                };
            }

            var loginEntity = this.loginEntityRepository.EntityQueryable.Where(p => p.Username == userName).Select(p => new { p.LoginId, p.IsEnabled }).FirstOrDefault();
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
                    LoginId = loginEntity.LoginId
                };
        }
    }
}