using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class LoginModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

    public enum LoginModelStatus
    { 
        Success,

        [DisplayText("用户名或密码错误")]
        InvalidCredential
    }
}