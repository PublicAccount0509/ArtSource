using Art.BussinessLogic.Entities;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Data.Domain.Access;
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
    public class AdminUserBussinessLogic
    {
        //public static readonly AdminUserBussinessLogic Instance = new AdminUserBussinessLogic();

        private readonly IRepository<AdminUser> _adminUserRepository;
        private AdminUserBussinessLogic(IRepository<AdminUser> adminUserRepository)
        {
            _adminUserRepository = adminUserRepository;
        }

        public void AddTestAdminUser()
        {

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
    }
}
