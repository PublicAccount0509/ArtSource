using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 我乐意数据
    /// </summary>
    public class CustomerProfile
    {
        /// <summary>
        /// 用户头像
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 艺术指数
        /// </summary>
        public float ArtIndex { get; set; }

        /// <summary>
        /// 收藏数量
        /// </summary>
        public int CollectCount { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// 赞数量
        /// </summary>
        public int PraiseCount { get; set; }

        /// <summary>
        /// 关注数量
        /// </summary>
        public int FollowCount { get; set; }

        /// <summary>
        /// 最近的4个
        /// </summary>
        public ArtworkSimpleModel[] LatestCollectArtworks { get; set; }
    }

    public enum GetCustomerProfileStatus
    { 
        Success,

        [DisplayText("用户不存在")]
        InvalidUserId,
    }

    public class CustomerProfileTranslator : TranslatorBase<Customer, CustomerProfile>
    {
        public static readonly CustomerProfileTranslator Instance = new CustomerProfileTranslator();

        public override CustomerProfile Translate(Customer from)
        {
            var to = new CustomerProfile();
            to.UserName = from.NickName;
            to.IconPath = string.Empty;//TODO
            return to;
        }

        public override Customer Translate(CustomerProfile from)
        {
            throw new NotImplementedException();
        }
    }
}