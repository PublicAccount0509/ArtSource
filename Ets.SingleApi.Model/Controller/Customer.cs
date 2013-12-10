namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：Customer
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：用户信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 18:10
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class Customer
    {
        /// <summary>
        /// Gets or sets the UserId of User
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Avatar of User
        /// </summary>
        /// <value>
        /// The Avatar
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets the Telephone of User
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the Email of User
        /// </summary>
        /// <value>
        /// The Email
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the SupplierId of Customer
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/10/2013 9:14 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the CustomerAddressList of Customer
        /// </summary>
        /// <value>
        /// The CustomerAddressList
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<CustomerAddress> CustomerAddressList { get; set; }
    }
}