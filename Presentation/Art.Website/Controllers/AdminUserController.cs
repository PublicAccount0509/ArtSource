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

        [HttpPost]
        public JsonResult Add(AdminUserModel model)
        {
            var seachByLoginNameResult = _adminUserBussinessLogic.GetUserByLoginName(model.LoginName);
            if (seachByLoginNameResult != null)
            {
                return Json(new ResultModel(false, "登录名已被抢先占用"));
            }
            var entity = AdminUserModelTranslator.Instance.Translate(model);
            _adminUserBussinessLogic.AddAdminUser(entity);
            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Edit(AdminUserModel model)
        {
            var resultEntity = _adminUserBussinessLogic.GetById(model.Id);
            if (resultEntity == null)
            {
                return Json(new ResultModel(false, "用户不存在"));
            }
            var seachByLoginNameResult = _adminUserBussinessLogic.GetUserByLoginName(model.LoginName);
            if (seachByLoginNameResult != null && seachByLoginNameResult.Id != model.Id)
            {
                return Json(new ResultModel(false, "登录名已被抢先占用"));
            }

            //var entity = AdminUserModelTranslator.Instance.Translate(model);
            resultEntity.Contact = model.Contact;
            resultEntity.LoginName = model.LoginName;
            resultEntity.Name = model.Name;
            resultEntity.Position = model.Position;
            _adminUserBussinessLogic.UpdateAdminUser(resultEntity);
            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var resultEntity = _adminUserBussinessLogic.GetById(id);
            if (resultEntity == null)
            {
                return Json(new ResultModel(false, "用户不存在"));
            }
            _adminUserBussinessLogic.DeleteAdminUser(resultEntity);
            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }
        [HttpPost]
        public JsonResult CheckPassword(AdminUserModel model)
        {
            return Json(Checkpassword(model.Id, model.PassWord));
        }

        private ResultModel Checkpassword(int id, string passWord)
        {
            var resultEntity = _adminUserBussinessLogic.GetById(id);
            if (resultEntity == null)
            {
                return new ResultModel(false, "用户不存在");
            }
            return
                !resultEntity.Password.Equals(passWord)
                         ? new ResultModel(false, "用户名或密码错")
                         : new ResultModel(true, string.Empty);
        }

        [HttpPost]
        public JsonResult ResetPassword(ResetPasswordModel model)
        {
            if (string.IsNullOrEmpty(model.NewPassword))
            {
                return Json(new ResultModel(false, "密码不能为空"));
            }
            var chekResult = this.Checkpassword(model.Id, model.Password);
            if (!chekResult.IsSuccess)
            {
                return Json(chekResult);
            }
            var resultEntity = _adminUserBussinessLogic.GetById(model.Id);
            resultEntity.Password = model.NewPassword;
            _adminUserBussinessLogic.UpdateAdminUser(resultEntity);
            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }
    }
}
