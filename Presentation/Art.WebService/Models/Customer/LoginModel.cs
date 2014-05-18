using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class LoginModel
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
    }

    public enum LoginModelStatus
    { 
        Success,

        [DisplayText("用户名或密码错误")]
        InvalidCredential
    }
}