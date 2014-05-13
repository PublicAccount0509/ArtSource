using Art.BussinessLogic;
using Art.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Art.WebService.Controllers
{
    public class UserController : ApiController
    {
        // GET api/user
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public ResultModel Register(CustomerRegisterModel model)
        {
            if (string.IsNullOrEmpty(model.NickName))
            {
                return new ResultModel(false, "昵称不能为空");
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                return new ResultModel(false, "手机号不能为空");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                return new ResultModel(false, "密码不能为空");
            }
            if (CustomerBussinessLogic.Instance.ExistNickName(model.NickName))
            {
                return new ResultModel(false, "昵称已被注册");
            }
            if (CustomerBussinessLogic.Instance.ExistPhoneNumber(model.PhoneNumber))
            {
                return new ResultModel(false, "手机号已被注册");
            }

            var customer = CustomerRegisterModelTranslator.Instance.Translate(model);
            var customerAdded = CustomerBussinessLogic.Instance.Add(customer);

            return new ResultModel(true, customerAdded.Id);
        }

        [HttpPost]
        public ResultModel Login(LoginModel model)
        {
            var flg = CustomerBussinessLogic.Instance.ValidateLogin(model.LoginName,model.Password);
            return new ResultModel(flg);
        }


    }
}
