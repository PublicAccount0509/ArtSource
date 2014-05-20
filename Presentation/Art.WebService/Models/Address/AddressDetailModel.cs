
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
    public class AddressDetailModel
    {

        public int Id { get; set; }

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


    public class AddressDetailModelTranslator : TranslatorBase<Address, AddressDetailModel>
    {
        public static readonly AddressDetailModelTranslator Instance = new AddressDetailModelTranslator();

        public override AddressDetailModel Translate(Address from)
        {
            var to = new AddressDetailModel();
            to.Id = from.Id;
            to.UserId = from.Customer.Id;
            to.Detail = from.Detail;
            to.ReceiptName = from.Name;
            to.PhoneNumber = from.Telephone;
            to.IsDefault = from.Customer.DefaultAddressId == from.Id;
            return to;
        }

        public override Address Translate(AddressDetailModel from)
        {
            throw new NotImplementedException();
        }
    }
}