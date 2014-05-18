using Art.BussinessLogic;
using Art.Common;
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
                return IntResultModel.Conclude(CustomerRegisterStatus.NickNameEmpty);//, "昵称不能为空");
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                return IntResultModel.Conclude(CustomerRegisterStatus.PhoneNumberEmpty);//, "手机号不能为空");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                return IntResultModel.Conclude(CustomerRegisterStatus.PasswordEmpty);
            }
            if (_customerBussinessLogic.ExistNickName(model.NickName))
            {
                return IntResultModel.Conclude(CustomerRegisterStatus.NickNameAlreadyRegistered);//, "昵称已被注册");
            }
            if (_customerBussinessLogic.ExistPhoneNumber(model.PhoneNumber))
            {
                return IntResultModel.Conclude(CustomerRegisterStatus.PhoneNumberRegistered);//, "手机号已被注册");
            }

            var customer = CustomerRegisterModelTranslator.Instance.Translate(model);
            var customerAdded = _customerBussinessLogic.Add(customer);

            return IntResultModel.Conclude(CustomerRegisterStatus.Success, customerAdded.Id);
        }

        [HttpPost]
        //可以使用昵称或者手机号码登录
        public IntResultModel Login(LoginModel model)
        {
            var customer = _customerBussinessLogic.RetrieveCustomer(model.LoginName, model.Password);
            if (customer == null)
            {
                return IntResultModel.Conclude(LoginModelStatus.InvalidCredential);
            }
            return IntResultModel.Conclude(LoginModelStatus.Success, customer.Id);
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
        public IntResultModel AddAddress(AddAddressModel model)
        {
            if (string.IsNullOrEmpty(model.Detail))
            {
                return IntResultModel.Conclude(AddAddressStatus.DetailEmpty);
            }

            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                return IntResultModel.Conclude(AddAddressStatus.PhoneNumberEmpty);
            }

            if (string.IsNullOrEmpty(model.ReceiptName))
            {
                return IntResultModel.Conclude(AddAddressStatus.ReceiptNameEmpty);
            }

            var customer = _customerBussinessLogic.Get(model.UserId);
            if (customer == null)
            {
                return IntResultModel.Conclude(AddAddressStatus.UserNotExist);
            }

            var address = AddAddressModelTranslator.Instance.Translate(model);
            address.Customer = customer;
            if (model.IsDefault == true)
            {
                customer.DefaultAddress = address;
            }
            var resultAdd = _customerBussinessLogic.AddAddress(address);
            return IntResultModel.Conclude(AddAddressStatus.Success, resultAdd.Id);
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
        public SimpleResultModel EditAddress(UpdateAddressModel model)
        {
            if (string.IsNullOrEmpty(model.Detail))
            {
                return SimpleResultModel.Conclude(UpdateAddressStatus.DetailEmpty);
            }

            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                return SimpleResultModel.Conclude(UpdateAddressStatus.PhoneNumberEmpty);
            }

            if (string.IsNullOrEmpty(model.ReceiptName))
            {
                return SimpleResultModel.Conclude(UpdateAddressStatus.ReceiptNameEmpty);
            }

            var address = _customerBussinessLogic.GetAddressById(model.Id);
            if (address == null)
            {
                return SimpleResultModel.Conclude(UpdateAddressStatus.AddressIdNotExist);
            }

            if (model.IsDefault == true)
            {
                address.Customer.DefaultAddressId = address.Id;
            }
            address.Detail = model.Detail;
            address.Name = model.ReceiptName;
            address.Telephone = model.PhoneNumber;

            _customerBussinessLogic.UpdateAddress(address);

            return SimpleResultModel.Conclude(UpdateAddressStatus.Success);
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
        public SimpleResultModel RemoveAddress(int id)
        {
            var address = _customerBussinessLogic.GetAddressById(id);
            if (address == null)
            {
                return SimpleResultModel.Conclude(DeleteAddressStatus.AddressIdNotExist);
            }

            //if (address.Customer.DefaultAddressId == address.Id)
            //{
            //    address.Customer.DefaultAddressId = null;
            //    address.Customer.DefaultAddress = null;
            //}

            _customerBussinessLogic.RemoveAddress(address);

            return SimpleResultModel.Conclude(DeleteAddressStatus.Success);
        }

        [HttpGet]
        public ResultModel<AddAddressModel[]> MyAddresses(int userId)
        {
            var addresses = _customerBussinessLogic.GetMyAddresses(userId);
            var result = AddAddressModelTranslator.Instance.Translate(addresses);
            return ResultModel<AddAddressModel[]>.Conclude(GetMyAddressesStatus.Success, result.ToArray());
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
                return SimpleResultModel.Conclude(ResetPasswordStatus.NewPasswordEmpty);//, "新密码不能为空");
            }
            var customer = _customerBussinessLogic.Get(model.UserId);
            if (customer == null)
            {
                return SimpleResultModel.Conclude(ResetPasswordStatus.UserNotExist);//, "用户不存在");
            }
            if (!customer.Password.Equals(model.CurrentPassword))
            {
                return SimpleResultModel.Conclude(ResetPasswordStatus.InvalidCurrentPassword);
            }
            customer.Password = model.NewPassword;
            _customerBussinessLogic.UpdateCustomer(customer);

            return SimpleResultModel.Conclude(ResetPasswordStatus.Success);
        }

        [HttpGet]
        public SimpleResultModel CheckCode(string PhoneNumber)
        {
            if (!CommonValidator.IsValidPhoneNumber(PhoneNumber))
            {
                return SimpleResultModel.Conclude(SendCheckCodeStatus.InvlidPhoneNumber);
            }
            //TODO:send sms
            return SimpleResultModel.Conclude(SendCheckCodeStatus.Success);
        }

    }
}
