using Art.BussinessLogic.Entities;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
namespace Art.BussinessLogic
{
    public interface IAdminUserBussinessLogic
    {
        IList<AdminUser> SearchAdminUser(AdminUserSearchCriteria criteria);
        UserLoginResults ValidateUser(string userName, string password);
    }
}
