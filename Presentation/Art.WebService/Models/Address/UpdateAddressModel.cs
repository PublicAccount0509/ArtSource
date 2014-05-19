using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;
using System.Web.Http;
using Art.BussinessLogic;

namespace Art.WebService.Models
{
    /// <summary>
    /// 编辑地址数据
    /// </summary>
    public class UpdateAddressModel
    {
        /// <summary>
        /// 地址Id
        /// </summary>
        public int Id { get; set; }
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
      
    public enum UpdateAddressStatus
    {
        Success,

        [DisplayText("地址不能为空")]
        DetailEmpty,

        [DisplayText("手机号不能为空")]
        PhoneNumberEmpty,

        [DisplayText("收货人不能为空")]
        ReceiptNameEmpty,

        [DisplayText("您想要修改的地址不存在")]
        AddressIdNotExist
    }
     
    public enum DeleteAddressStatus
    {
        Success,

        [DisplayText("您想要删除的地址不存在")]
        AddressIdNotExist
    }

    public enum GetMyAddressesStatus
    {
        Success
    }
      
    public class UpdateAddressModelTranslator : TranslatorBase<Address, UpdateAddressModel>
    {
        public static readonly UpdateAddressModelTranslator Instance = new UpdateAddressModelTranslator();

        public override UpdateAddressModel Translate(Address from)
        {
            throw new NotImplementedException();
        }

        public override Address Translate(UpdateAddressModel from)
        {
            var logic = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICustomerBussinessLogic)) as ICustomerBussinessLogic;

            var to = logic.GetAddressById(from.Id);
            to.Name = from.ReceiptName;
            to.Detail = from.Detail;
            to.Telephone = from.PhoneNumber; 
            if (from.IsDefault)
            {
                to.Customer.DefaultAddress = to;
            }
            return to;
        }
    } 
}