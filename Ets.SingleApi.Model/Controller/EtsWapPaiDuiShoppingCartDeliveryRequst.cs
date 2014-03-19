namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：EtsWapPaiDuiShoppingCartCustomerRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 10:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapPaiDuiShoppingCartDeliveryRequst : ApiRequst
    {
        /// <summary>
        /// 设置或取得用户姓名
        /// </summary>
        /// <value>
        /// 用户姓名
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Name { get; set; }

        /// <summary>
        /// 设置或取得用户联系电话
        /// </summary>
        /// <value>
        /// 用户联系电话
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// 设置或取得用户性别
        /// </summary>
        /// <value>
        /// 用户性别
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Gender { get; set; }

        /// <summary>
        /// 设置或取得用户Ip地址
        /// </summary>
        /// <value>
        /// 用户Ip地址
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:40 AM
        /// 修改者：
        /// 修改时间：
        public string IpAddress { get; set; }

        /// <summary>
        /// 设置或取得用户地址Id
        /// </summary>
        /// <value>
        /// 用户地址Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? CustomerAddressId { get; set; }
    }
}