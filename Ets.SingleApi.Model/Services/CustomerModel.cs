namespace Ets.SingleApi.Model.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：CustomerModel
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：用户信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 18:10
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CustomerModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerModel"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 19:46
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CustomerModel()
        {
            this.CustomerAddressList = new List<CustomerAddressModel>();
        }

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
        /// Gets or sets the CustomerId of CustomerModel
        /// </summary>
        /// <value>
        /// The CustomerId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 19:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CustomerId { get; set; }

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
        /// Gets or sets the Avatar of CustomerModel
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
        /// Gets or sets the Telephone of CustomerModel
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
        /// Gets or sets the Email of CustomerModel
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
        public List<CustomerAddressModel> CustomerAddressList { get; set; }
    }
}