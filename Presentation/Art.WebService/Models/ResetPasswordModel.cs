using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        UserNotExist,
        InvalidCurrentPassword,
        NewPasswordEmpty
    }
}