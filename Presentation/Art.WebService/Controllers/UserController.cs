﻿using Art.BussinessLogic;
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
        //可以使用昵称或者手机号码登录
        public SimpleResultModel Login(LoginModel model)
        {
            var flg = CustomerBussinessLogic.Instance.ValidateLogin(model.LoginName, model.Password);
            return new SimpleResultModel(flg);
        }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// ResultModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public ResultModel AddAddress(AddressModel model)
        {
            string message;
            if (!CheckAddressModel(model, out message))
            {
                return new ResultModel(false, message);
            }

            var customer = CustomerBussinessLogic.Instance.Get(model.UserId);
            if (customer == null)
            {
                return new ResultModel(false, "用户不存在");
            }
            
            var address = AddressModelTranslator.Instance.Translate(model);
            address.Customer = customer;
            if (model.IsDefault == true)
            {
                customer.DefaultAddress = address;
            }
            var resultAdd = CustomerBussinessLogic.Instance.AddAddress(address);
            return new ResultModel(true,resultAdd.Id);
        }

        /// <summary>
        /// Edits the address.
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// ResultModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 10:53 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public ResultModel EditAddress(AddressModel model)
        {
            string message;
            if (!CheckAddressModel(model, out message))
            {
                return new ResultModel(false, message);
            }

            var address = CustomerBussinessLogic.Instance.GetAddressById(model.Id);
            if (address == null)
            {
                return new ResultModel(false, "您想要修改的地址不存在");
            }
            if (model.IsDefault == true)
            {
                if (address.Customer == null)
                {
                    return new ResultModel(false, "该地址对应的用户不存在，无法设置默认地址");
                }
                address.Customer.DefaultAddressId = address.Id;
            }
            address.Detail = model.Detail;
            address.Name = model.ReceiptName;
            address.Telephone = model.PhoneNumber;
            CustomerBussinessLogic.Instance.UpdateAddress(address);
            return new ResultModel(true);
        }

        public bool CheckAddressModel(AddressModel model, out string message)
        {
            message = string.Empty;
            var ret = true;
            if (string.IsNullOrEmpty(model.Detail))
            {
                message = "地址不能为空 ";
            }
            else if (model.Detail.Trim().Length == 0)
            {
                message = "地址不能为空";
            }
            else if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                message = "手机号不能为空";
            }
            else if (model.PhoneNumber.Trim().Length == 0)
            {
                message = "手机号不能为空";
            }
            else if (string.IsNullOrEmpty(model.ReceiptName))
            {
                message = "联系人不能为空";
            }
            else if (model.ReceiptName.Trim().Length == 0)
            {
                message = "联系人不能为空";
            }
            if (!"".Equals(message))
            {
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// Removes the address.
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// ResultModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 11:01 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public ResultModel RemoveAddress(AddressModel model)
        {
            var address = CustomerBussinessLogic.Instance.GetAddressById(model.Id);
            if (address == null)
            {
                return new ResultModel(false, "您想要删除的地址不存在");
            }
            if (address.Customer != null && address.Customer.DefaultAddressId == address.Id)
            {
                address.Customer.DefaultAddressId = null;
                address.Customer.DefaultAddress = null;
            }
            CustomerBussinessLogic.Instance.RemoveAddress(address);
            return new ResultModel(true);
        }
    }
}
