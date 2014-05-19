using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 重置密码数据
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string CurrentPassword { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
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