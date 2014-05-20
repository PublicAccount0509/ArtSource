using Art.BussinessLogic;
using Art.BussinessLogic.Entities;
using Art.Common;
using Art.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebExpress.Core;

namespace Art.WebService.Controllers
{
    public class UserController : ApiController
    {
        private ICustomerBussinessLogic _customerBussinessLogic;
        private IArtworkBussinessLogic _artworkBussinessLogic;
        private IArtistBussinessLogic _artistBussinessLogic;
        public UserController(ICustomerBussinessLogic customerBussinessLogic,
            IArtworkBussinessLogic artworkBussinessLogic,
            IArtistBussinessLogic artistBussinessLogic)
        {
            _customerBussinessLogic = customerBussinessLogic;
            _artworkBussinessLogic = artworkBussinessLogic;
            _artistBussinessLogic = artistBussinessLogic;
        }

        // GET api/user
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        [ActionStatus(typeof(CustomerRegisterStatus))]
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

        /// <summary>
        /// 用户登录
        /// 
        /// 可以使用昵称或者手机号码登录
        /// </summary>
        [ActionStatus(typeof(LoginModelStatus))]
        [HttpPost]
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
        /// 添加地址
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [ActionStatus(typeof(AddAddressStatus))]
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
                address.Customer.DefaultAddress = address;
            }
            var resultAdd = _customerBussinessLogic.AddAddress(address);
            return IntResultModel.Conclude(AddAddressStatus.Success, resultAdd.Id);
        }

        /// <summary>
        /// 编辑地址
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 10:53 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [ActionStatus(typeof(UpdateAddressStatus))]
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
        /// 删除地址
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 11:01 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [ActionStatus(typeof(DeleteAddressStatus))]
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
        /// <summary>
        /// 获取所有我的地址
        /// </summary>
        [ActionStatus(typeof(GetMyAddressesStatus))]
        [HttpGet]
        public ResultModel<AddressDetailModel[]> MyAddresses(int userId)
        {
            var addresses = _customerBussinessLogic.GetMyAddresses(userId);
            var result = AddressDetailModelTranslator.Instance.Translate(addresses);
            return ResultModel<AddressDetailModel[]>.Conclude(GetMyAddressesStatus.Success, result.ToArray());
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：5/16/2014 10:46 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [ActionStatus(typeof(ResetPasswordStatus))]
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

        /// <summary>
        /// 请求动态验证码
        /// </summary>
        [ActionStatus(typeof(SendCheckCodeStatus))]
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

        /// <summary>
        /// 我乐意的数据
        /// </summary>
        [ActionStatus(typeof(GetCustomerProfileStatus))]
        [HttpGet]
        public ResultModel<CustomerProfile> Profile(int userId)
        {
            var customer = _customerBussinessLogic.Get(userId);
            if (customer == null)
            {
                ResultModel<CustomerProfile>.Conclude(GetCustomerProfileStatus.InvalidUserId);
            }
            var result = CustomerProfileTranslator.Instance.Translate(customer);

            result.CollectCount = _artworkBussinessLogic.GetCollectCount(userId);
            result.PraiseCount = _artworkBussinessLogic.GetCollectCount(userId);
            result.CommentCount = _artworkBussinessLogic.GetCommentCount(userId);
            result.FollowCount = _artistBussinessLogic.GetFollowCount(userId);

            var shareCount = _artworkBussinessLogic.GetShareCount(userId);

            var score = (result.CollectCount + result.PraiseCount + shareCount) * 0.5;
            result.ArtIndex = GetHeartCount(score);

            var paging = new PagingRequest(0, 4);
            var criteria = new ArtworkSearchCriteria(paging) { CollectionCustomerId = userId };
            result.LatestCollectArtworks = SearchArtworkAndAttachCount(criteria);

            return ResultModel<CustomerProfile>.Conclude(GetCustomerProfileStatus.Success, result);
        }
        private int GetHeartCount(double score)
        {
            var intScore = (int)score;
            var heartCount = 0;

            if (heartCount.InRange(4, 10))
            {
                heartCount = 1;
            }
            else if (heartCount.InRange(11, 40))
            {
                heartCount = 2;
            }
            else if (heartCount.InRange(41, 90))
            {
                heartCount = 3;
            }
            else if (heartCount.InRange(91, 150))
            {
                heartCount = 4;
            }
            else if (heartCount.InRange(151, 250))
            {
                heartCount = 5;
            }
            else
            {
                heartCount = 5;
            }
            return intScore;
        }

        private ArtworkSimpleModel[] SearchArtworkAndAttachCount(ArtworkSearchCriteria criteria)
        {
            var artworks = _artworkBussinessLogic.SearchArtworks(criteria);

            var models = ArtworkSimpleModelTranslator.Instance.Translate(artworks);
            foreach (var model in models)
            {
                model.ShareCount = _artworkBussinessLogic.GetSharedCount(model.Id);
                model.CollectAccount = _artworkBussinessLogic.GetCollectedCount(model.Id);
                model.PraiseCount = _artworkBussinessLogic.GetPraisedCount(model.Id);
            }

            return models.ToArray();
        }

        /// <summary>
        /// 获取我的评价信息
        /// </summary>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<MyCommentModel[]> MyComments(int userId)
        {
            var list = _customerBussinessLogic.GetCommons(userId);
            var results = MyCommentModelTranslator.Instance.Translate(list).ToArray();
            return ResultModel<MyCommentModel[]>.Conclude(StandaloneStatus.Success, results);
        }
    }
}
