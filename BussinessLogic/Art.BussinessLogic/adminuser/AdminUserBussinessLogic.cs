using Art.BussinessLogic.Entities;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Data.Domain.Access;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.BussinessLogic
{
    /// <summary>
    /// 类名称：AdminUserBussinessLogic
    /// 命名空间：Art.BussinessLogic
    /// 类功能：
    /// </summary>
    /// 创建者：黄磊
    /// 创建日期：5/13/2014 5:22 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AdminUserBussinessLogic : Art.BussinessLogic.IAdminUserBussinessLogic
    {
        //public static readonly AdminUserBussinessLogic Instance = new AdminUserBussinessLogic();

        private  IRepository<AdminUser> _adminUserRepository;
        [InjectionMethod]
        public void Initialize(IRepository<AdminUser> adminUserRepository)
        {
            _adminUserRepository = adminUserRepository;
        }
         

        /// <summary>
        /// Searches the admin user.
        /// </summary>
        /// <param name="criteria">The criteria</param>
        /// <returns>
        /// IList{AdminUser}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/13/2014 5:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IList<AdminUser> SearchAdminUser(AdminUserSearchCriteria criteria)
        {
            var query = _adminUserRepository.Table.Where(p => (string.IsNullOrEmpty(criteria.Name) || p.Name.Contains(criteria.Name)));
            query = query.OrderByDescending(i => i.Id);
            return query.ToList();
        }

        public UserLoginResults ValidateUser(string userName, string password)
        {
            var user = _adminUserRepository.Table.Where(i => i.LoginName == userName).FirstOrDefault();
            if (user == null)
            {
                return UserLoginResults.UserNotExist;
            }
            if (user.Password != password)
            {
                return UserLoginResults.WrongPassword;
            }
            return UserLoginResults.Successful;
        }
    }
}
