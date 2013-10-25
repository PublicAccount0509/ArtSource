namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：ExistRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：用户存在参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 9:30
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ExistRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the Email of ExistRequst
        /// </summary>
        /// <value>
        /// The Email
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:52
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Telephone of ExistRequst
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }
    }
}