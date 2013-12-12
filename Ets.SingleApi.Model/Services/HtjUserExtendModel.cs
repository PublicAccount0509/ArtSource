namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：HtjUserExtendModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：黄太吉注册用户参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/14 10:03
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HtjUserExtendModel
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="HtjUserExtendModel"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/12/2013 6:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HtjUserExtendModel()
        {
            this.User = new HtjUserModel();
            this.UserToken = new UserTokenModel();
        }

        /// <summary>
        /// Gets or sets the User of HtjUserExtendModel
        /// </summary>
        /// <value>
        /// The User
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:20
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HtjUserModel User { get; set; }

        /// <summary>
        /// Gets or sets the UserToken of HtjUserExtendModel
        /// </summary>
        /// <value>
        /// The UserToken
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 10:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserTokenModel UserToken { get; set; }
    }
}