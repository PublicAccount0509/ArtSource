using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; 
using WebMatrix.WebData;
using Art.Website.Models;
using Art.Website.Authentication;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using Art.BussinessLogic;
using WebExpress.Core;

namespace Art.Website.Controllers
{ 
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationService;
        private IAdminUserBussinessLogic _adminUserBussinessLogic;
        public AccountController(IAdminUserBussinessLogic logic)
        {
            _adminUserBussinessLogic = logic;
            _authenticationService = new FormAuthenticationService();
        } 

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (model.Captcha != Session["captcha"].ToString())
            {
                ModelState.AddModelError("", "验证码输入不正确");
            }
            if (ModelState.IsValid)
            {
                var loginResult = _adminUserBussinessLogic.ValidateUser(model.UserName, model.Password);
                switch (loginResult)
                {
                    case Art.Data.Domain.UserLoginResults.Successful:
                        _authenticationService.SignIn(model.UserName, model.RememberMe);
                        return RedirectToLocal(returnUrl);
                    case Art.Data.Domain.UserLoginResults.UserNotExist:
                        ModelState.AddModelError("", "用户不存在！");
                        break;
                    case Art.Data.Domain.UserLoginResults.WrongPassword:
                    default:
                        ModelState.AddModelError("", "密码错误！");
                        break;
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _authenticationService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public FileContentResult CaptchaImage()
        {
            var captcha = new LiteralCaptcha(80, 25, 4);
            var bytes = captcha.Generate();
            Session["captcha"] = captcha.Captcha;
            return new FileContentResult(bytes, "image/jpeg"); ;
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
