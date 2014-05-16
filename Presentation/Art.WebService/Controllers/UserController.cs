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
        private ICustomerBussinessLogic _customerBussinessLogic;
        public UserController(ICustomerBussinessLogic customerBussinessLogic)
        {
            _customerBussinessLogic = customerBussinessLogic;
        }

        // GET api/user
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IntResultModel Register(CustomerRegisterModel model)
        {
            if (string.IsNullOrEmpty(model.NickName))
            {
                return new IntResultModel((int)CustomerRegisterStatus.NickNameEmpty, "昵称不能为空");
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                return new IntResultModel((int)CustomerRegisterStatus.PhoneNumberEmpty, "手机号不能为空");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                return new IntResultModel((int)CustomerRegisterStatus.PasswordEmpty, "密码不能为空");
            }
            if (_customerBussinessLogic.ExistNickName(model.NickName))
            {
                return new IntResultModel((int)CustomerRegisterStatus.NickNameAlreadyRegistered, "昵称已被注册");
            }
            if (_customerBussinessLogic.ExistPhoneNumber(model.PhoneNumber))
            {
                return new IntResultModel((int)CustomerRegisterStatus.PhoneNumberRegistered, "手机号已被注册");
            }

            var customer = CustomerRegisterModelTranslator.Instance.Translate(model);
            var customerAdded = _customerBussinessLogic.Add(customer);

            return new IntResultModel((int)CustomerRegisterStatus.Success, string.Empty, customerAdded.Id);
        }

        [HttpPost]
        //可以使用昵称或者手机号码登录
        public IntResultModel Login(LoginModel model)
        {
            var customer = _customerBussinessLogic.RetrieveCustomer(model.LoginName, model.Password);
            if (customer == null)
            {
                return new IntResultModel((int)LoginModelStatus.InvalidCredential, "登录失败");
            }
            return new IntResultModel((int)LoginModelStatus.Success, string.Empty, customer.Id);
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
        public IntResultModel AddAddress(AddressModel model)
        {
            string message;
            var status = CheckAddressModel(model, out message);
            if (status != SaveAddressStatus.Success)
            {
                return new IntResultModel((int)status, message);
            }

            var customer = _customerBussinessLogic.Get(model.UserId);
            if (customer == null)
            {
                return new IntResultModel((int)SaveAddressStatus.UserNotExist, "用户不存在");
            }

            var address = AddressModelTranslator.Instance.Translate(model);
            address.Customer = customer;
            if (model.IsDefault == true)
            {
                customer.DefaultAddress = address;
            }
            var resultAdd = _customerBussinessLogic.AddAddress(address);
            return new IntResultModel((int)SaveAddressStatus.Success, resultAdd.Id);
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
        public IntResultModel EditAddress(AddressModel model)
        {
            string message;
            var status = CheckAddressModel(model, out message);
            if (status != SaveAddressStatus.Success)
            {
                return new IntResultModel((int)status, message);
            }

            var address = _customerBussinessLogic.GetAddressById(model.Id);
            if (address == null)
            {
                return new IntResultModel((int)SaveAddressStatus.AddressIdNotExist, "您想要修改的地址不存在");
            }
            if (model.IsDefault == true)
            {
                if (address.Customer == null)
                {
                    return new IntResultModel((int)SaveAddressStatus.UserNotExist, "该地址对应的用户不存在，无法设置默认地址");
                }
                address.Customer.DefaultAddressId = address.Id;
            }
            address.Detail = model.Detail;
            address.Name = model.ReceiptName;
            address.Telephone = model.PhoneNumber;
            _customerBussinessLogic.UpdateAddress(address);
            return new IntResultModel((int)SaveAddressStatus.Success);
        }

        public SaveAddressStatus CheckAddressModel(AddressModel model, out string message)
        {
            message = string.Empty;
            if (string.IsNullOrEmpty(model.Detail))
            {
                message = "地址不能为空";
                return SaveAddressStatus.DetailEmpty;
            }

            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                message = "手机号不能为空";
                return SaveAddressStatus.PhoneNumberEmpty;
            }

            if (string.IsNullOrEmpty(model.ReceiptName))
            {
                message = "联系人不能为空";
                return SaveAddressStatus.ReceiptNameEmpty;
            }

            return SaveAddressStatus.Success;
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
        public SimpleResultModel RemoveAddress(AddressModel model)
        {
            var address = _customerBussinessLogic.GetAddressById(model.Id);
            if (address == null)
            {
                return new SimpleResultModel((int)DeleteAddressStatus.AddressIdNotExist, "您想要删除的地址不存在");
            }
            if (address.Customer != null && address.Customer.DefaultAddressId == address.Id)
            {
                address.Customer.DefaultAddressId = null;
                address.Customer.DefaultAddress = null;
            }
            _customerBussinessLogic.RemoveAddress(address);
            return new SimpleResultModel((int)DeleteAddressStatus.Success);
        }

        [HttpGet]
        public ResultModel<AddressModel[]> MyAddresses(int userId)
        {
            var addresses = _customerBussinessLogic.GetMyAddresses(userId);
            var result = AddressModelTranslator.Instance.Translate(addresses);
            return new ResultModel<AddressModel[]>
            {
                Status = (int)GetMyAddressesStatus.Success,
                Result = result.ToArray()
            };
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// SimpleResultModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/16/2014 10:46 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public SimpleResultModel ResetPassword(ResetPasswordModel model)
        {
            if (string.IsNullOrEmpty(model.NewPassword))
            {
                return new SimpleResultModel((int)ResetPasswordStatus.NewPasswordEmpty, "新密码不能为空");
            }
            var customer = _customerBussinessLogic.Get(model.UserId);
            if (customer == null)
            {
                return new SimpleResultModel((int)ResetPasswordStatus.UserNotExist, "用户不存在");
            }
            if (!customer.Password.Equals(model.CurrentPassword))
            {
                return new SimpleResultModel((int)ResetPasswordStatus.InvalidCurrentPassword, "密码错误");
            }
            customer.Password = model.NewPassword;
            _customerBussinessLogic.UpdateCustomer(customer);
            return SimpleResultModel.Success();
        }
    }
}
