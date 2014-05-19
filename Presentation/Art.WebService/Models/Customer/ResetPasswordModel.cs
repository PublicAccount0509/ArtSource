using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class ResetPasswordModel
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public enum ResetPasswordStatus
    {
        Success,

        [DisplayText("用户不存在")]
        UserNotExist,

        [DisplayText("密码错误")]
        InvalidCurrentPassword,

        [DisplayText("新密码不能为空")]
        NewPasswordEmpty
    }
}