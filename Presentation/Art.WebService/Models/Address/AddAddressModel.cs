
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using Art.Data.Domain;
using System.Web.Http;
using Art.BussinessLogic;

namespace Art.WebService.Models
{ 
    /// <summary>
    /// 用户地址数据
    /// </summary>
    public class AddAddressModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ReceiptName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// 是否是默认地址
        /// </summary>
        public bool IsDefault { get; set; }
    }

    public enum AddAddressStatus
    {
        Success,

        [DisplayText("地址不能为空")]
        DetailEmpty,

        [DisplayText("手机号不能为空")]
        PhoneNumberEmpty,

        [DisplayText("收货人不能为空")]
        ReceiptNameEmpty,

        [DisplayText("用户不存在")]
        UserNotExist
    }

    public class AddAddressModelTranslator : TranslatorBase<Address, AddAddressModel>
    {
        public static readonly AddAddressModelTranslator Instance = new AddAddressModelTranslator();

        public override AddAddressModel Translate(Address from)
        {
            //var to = new AddAddressModel();
            //to.PhoneNumber = from.Telephone;
            //to.ReceiptName = from.Name;
            //to.UserId = from.Customer.Id;
            //to.Detail = from.Detail;
            //if (from.Customer.DefaultAddressId.HasValue)
            //{
            //    to.IsDefault = from.Customer.DefaultAddressId.Value == from.Id;
            //}
            //return to;
            throw new NotImplementedException();
        }

        public override Address Translate(AddAddressModel from)
        {
            var logic = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICustomerBussinessLogic)) as ICustomerBussinessLogic;

            var to = new Address();
            to.Name = from.ReceiptName;
            to.Detail = from.Detail;
            to.Telephone = from.PhoneNumber;
            to.Customer = logic.Get(from.UserId);
            if (from.IsDefault)
            {
                to.Customer.DefaultAddress = to;
            }
            return to;
        }
    }
}