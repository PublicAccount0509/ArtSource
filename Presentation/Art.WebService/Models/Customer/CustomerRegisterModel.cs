using Art.Data.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 注册用户数据
    /// </summary>
    public class CustomerRegisterModel
    {
        /// <summary>
        /// 性别
        /// </summary>
        public Genders Gender { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string CheckCode { get; set; }
        /// <summary>
        /// 0 ios 1 android
        /// </summary>
        public DeviceType DeviceType { get; set; }
    }

    public class CustomerRegisterModelTranslator : TranslatorBase<Customer, CustomerRegisterModel>
    {
        public static readonly CustomerRegisterModelTranslator Instance = new CustomerRegisterModelTranslator();

        public override CustomerRegisterModel Translate(Customer from)
        {
            throw new NotImplementedException();
        }

        public override Customer Translate(CustomerRegisterModel from)
        {
            var to = new Customer();
            to.NickName = from.NickName;
            to.Password = from.Password;
            to.PhoneNumber = from.PhoneNumber;
            return to;
        }
    }


    public enum CustomerRegisterStatus : int
    {
        Success = 0,

        [DisplayText("性别无效")]
        InvalidGender,

        [DisplayText("昵称不能为空")]
        NickNameEmpty,

        [DisplayText("手机号不能为空")]
        PhoneNumberEmpty,

        [DisplayText("密码不能为空")]
        PasswordEmpty,

        [DisplayText("验证码不正确")]
        IncorrectCheckCode,

        [DisplayText("昵称已被注册")]
        NickNameAlreadyRegistered,

        [DisplayText("手机号已被注册")]
        PhoneNumberRegistered
    }
}