using Art.BussinessLogic.Entities;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
namespace Art.BussinessLogic
{
    public interface IAdminUserBussinessLogic
    {
        IList<AdminUser> SearchAdminUser(AdminUserSearchCriteria criteria);
        void AddAdminUser(AdminUser adminUser);
        void UpdateAdminUser(AdminUser adminUser);
        void DeleteAdminUser(AdminUser adminUser);
        UserLoginResults ValidateUser(string userName, string password);
        bool CheakUserByLoginName(string loginName);
        AdminUser GetById(int adminUserId);
        AdminUser GetUserByLoginName(string loginName);
    }
}
