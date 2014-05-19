using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Art.BussinessLogic;
using Art.BussinessLogic.Entities;
using Art.Website.Models;

namespace Art.Website.Controllers
{
    public class AdminUserController : Controller
    {
        private IAdminUserBussinessLogic _adminUserBussinessLogic;
        public AdminUserController(IAdminUserBussinessLogic logic)
        {
            _adminUserBussinessLogic = logic;
        }


        /// <summary>
        /// The method will 
        /// </summary>
        /// <returns>
        /// The ActionResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/13/2014 5:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ActionResult List()
        {
            var models = GetAdminUsers(new AdminUserSearchCriteria());
            return View(models);
        }
        [HttpPost]
        public PartialViewResult List(AdminUserSearchCriteria criteria)
        {
            var model = GetAdminUsers(criteria);
            return PartialView("_List", model);
        }
        private IList<AdminUserModel> GetAdminUsers(AdminUserSearchCriteria criteria)
        {
            var adminUsers = _adminUserBussinessLogic.SearchAdminUser(criteria);
            var adminUserModels = adminUsers.Select(item => AdminUserModelTranslator.Instance.Translate(item)).ToList();
            return adminUserModels;
        }
    }
}
