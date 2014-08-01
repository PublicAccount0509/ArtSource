using System;

namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    public class SupplierLogin : ILogin
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

        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneLogin" /> class.
        /// </summary>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="supplierEntityRepository">The SupplierEntityRepositoryDefault documentation</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SupplierLogin(
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository)
        {
            this.loginEntityRepository = loginEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
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
                return LoginWay.SupplierUser;
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

            var loginEntity = this.loginEntityRepository.EntityQueryable.Where(p => p.Username == userName).Select(p => new { p.LoginId, p.Password, p.IsEnabled }).FirstOrDefault();
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

            //餐厅信息
            var supplierInfo =
                this.supplierEntityRepository.EntityQueryable.Where(c => c.Login.LoginId == loginEntity.LoginId)
                    .Select(s => new {s.SupplierId, s.Login.LoginId}).FirstOrDefault();

            if (supplierInfo == null)
            {
                return new LoginData
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserNameCode
                };
            }

            return new LoginData { LoginId = loginEntity.LoginId, SupplierId = supplierInfo.SupplierId };
        }

    }
}